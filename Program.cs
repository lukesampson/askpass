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

			var m = Regex.Match(args[0], "Enter passphrase for ([^:]+)", RegexOptions.IgnoreCase);
			if(!m.Success) {
				Log("error parsing arguments: " + string.Join(", ", args));
				return;
			}

			var key = m.Groups[1].Value;
			Log("key: " + key);

			var password = SavedPassword(key);
			if(password != null) {
				Log("found saved password");
				Console.WriteLine(password); // send password to ssh-add
			} else {
				Log("no saved password for " + key);
				password = PromptForPassword(key);
				if(password == null) {
					Environment.Exit(1); // failed: agent should ignore output
				}
				Log("collected password: " + password);							
				Console.WriteLine(password);
			}
		}

		static string PromptForPassword(string key) {
			Application.EnableVisualStyles();
			var prompt = new PasswordPrompt(key);
			var res = prompt.ShowDialog();
			if(res == DialogResult.OK) {
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

		static void Log(string message) {
			File.AppendAllText(log, message + "\r\n");
		}
	}
}
