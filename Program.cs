using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace askpass {
	class Program {
		static string log = null;

		static void Main(string[] args) {
			log = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "askpass.log");
			if(File.Exists(log)) { File.Delete(log); }

			var lastPassFail = false;
			var m = Regex.Match(args[0], "Enter passphrase for ([^:]+)", RegexOptions.IgnoreCase);
			if(!m.Success) {
				m = Regex.Match(args[0], "Bad passphrase, try again for ([^:]+)", RegexOptions.IgnoreCase);
				if(m.Success) {
					Log("last password failed");
					lastPassFail = true;
				} else {
					Log("error parsing arguments: " + string.Join(", ", args));
					Environment.Exit(1);
				}
			}

			var key = m.Groups[1].Value;

			// make it look like a windows path
			key = Regex.Replace(key, "/{2,}", "/"); // clean double slashes
			key = Regex.Replace(key, "^/([A-Za-z])/", "$1:/"); // drive
			key = Regex.Replace(key, "/", "\\"); // use backslashes

			Log("key: " + key);

			string password = null;
			if(lastPassFail) {
				Log("removing saved password");
				DeletePassword(key);
			} else {
				password = SavedPassword(key);
			}

			if(password != null) {
				Log("found saved password");
				Console.WriteLine(password); // send password to ssh-add
			} else {
				Log("no password saved for " + key);
				bool save;
				password = PromptForPassword(key, lastPassFail, out save);
				if(password == null) { // empty or cancelled
					// failed: agent should ignore output and not call askpass again
					Environment.Exit(1);
				}
				Log("collected password");
				if(save) {
					Log("saving password");
					SavePassword(key, password);
				}
				Console.WriteLine(password); // send password to ssh-add
			}
		}

		static string PromptForPassword(string key, bool lastPassFail, out bool save) {
			Application.EnableVisualStyles();
			var prompt = new PasswordPrompt(key, lastPassFail);
			var res = prompt.ShowDialog();
			save = false;
			if(res == DialogResult.OK) {
				if(string.IsNullOrEmpty(prompt.Password)) return null;
				save = prompt.Save;
				return prompt.Password;
			}
			return null;
		}

		static string SavedPassword(string key) {
			IntPtr credPtr = IntPtr.Zero;
			var ok = NativeMethods.CredRead("ssh:" + key, NativeMethods.CRED_TYPE.GENERIC, 0, out credPtr);
			if(!ok) return null;

			// Decode the credential
			var cred = (NativeMethods.CREDENTIAL)Marshal.PtrToStructure(credPtr, typeof(NativeMethods.CREDENTIAL));
			return Marshal.PtrToStringBSTR(cred.credentialBlob);
		}

		static bool SavePassword(string key, string password) {
			string target = "ssh:" + key;
			IntPtr passwordPtr = Marshal.StringToBSTR(password);
			NativeMethods.CREDENTIAL cred = new NativeMethods.CREDENTIAL() {
				type = 0x01, // Generic
				targetName = target,
				credentialBlob = Marshal.StringToCoTaskMemUni(password),
				persist = 0x02, // Local machine
				attributeCount = 0,
				userName = "(N/A)"
			};
			cred.credentialBlobSize = Encoding.Unicode.GetByteCount(password);
			if(!NativeMethods.CredWrite(ref cred, 0)) {
				Log("Failed to write credential: " + GetLastErrorMessage());
				return false;
			}
			return true;
		}

		static void DeletePassword(string key) {
			var target = "ssh:" + key;
            if (!NativeMethods.CredDelete(target, NativeMethods.CRED_TYPE.GENERIC, 0)) {
                Log("Failed to delete credential: " + GetLastErrorMessage());
            }
        }

		static string GetLastErrorMessage() {
			return new Win32Exception(Marshal.GetLastWin32Error()).Message;
		}

		static void Log(string message) {
			File.AppendAllText(log, message + "\r\n");
		}
	}
}
