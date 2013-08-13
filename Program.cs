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
				Log("got saved password: " + password);
				Console.WriteLine(password);
			} else {
				Log("no saved password for " + key);
				password = PromptForPassword(key);
				if(password == null) {
					Environment.Exit(1); // failed: agent should ignore output
				}

				Log("collected password: " + password);								
			}
		}

		static string PromptForPassword(string key) {
			var credPtr = IntPtr.Zero;
			string username = null;
			string password = null;

			// If we have a username, pack an input authentication buffer
			Tuple<int, IntPtr> inputBuffer = null; ;
			IntPtr outputBuffer = IntPtr.Zero;
			int outputBufferSize = 0;
			try {
				inputBuffer = PackUserNameBuffer(username);
				if(inputBuffer == null) { return null; }

				// Setup UI
				NativeMethods.CREDUI_INFO ui = new NativeMethods.CREDUI_INFO() {
					pszCaptionText = "SSH Key password",
					pszMessageText = "Enter the passphrase for " + key
				};
				ui.cbSize = Marshal.SizeOf(ui);

				// Prompt!
				int authPackage = 0;
				bool save = false;
				var ret = NativeMethods.CredUIPromptForWindowsCredentials(
					uiInfo: ref ui,
					authError: 0,
					authPackage: ref authPackage,
					InAuthBuffer: inputBuffer.Item2,
					InAuthBufferSize: inputBuffer.Item1,
					refOutAuthBuffer: out outputBuffer,
					refOutAuthBufferSize: out outputBufferSize,
					fSave: ref save,
					flags: NativeMethods.PromptForWindowsCredentialsFlags.CREDUIWIN_GENERIC);
				if(ret != NativeMethods.CredUIReturnCodes.NO_ERROR) {
					Log("Error prompting for credentials: " + ret.ToString());
					return null;
				}
			} finally {
				if(inputBuffer != null && inputBuffer.Item2 != IntPtr.Zero) {
					Marshal.FreeHGlobal(inputBuffer.Item2);
				}
			}

			try {
				// Unpack
				if(!UnPackAuthBuffer(outputBuffer, outputBufferSize, out username, out password)) {
					return null;
				}
			} finally {
				if(outputBuffer != IntPtr.Zero) {
					Marshal.FreeHGlobal(outputBuffer);
				}
			}

			return password;
		}
		private static bool UnPackAuthBuffer(IntPtr buffer, int size, out string userName, out string password) {
			userName = String.Empty;
			password = String.Empty;

			StringBuilder userNameBuffer = new StringBuilder(255);
			StringBuilder passwordBuffer = new StringBuilder(255);
			StringBuilder domainBuffer = new StringBuilder(255);
			int userNameSize = 255;
			int passwordSize = 255;
			int domainSize = 255;
			if(!NativeMethods.CredUnPackAuthenticationBuffer(
				dwFlags: 0,
				pAuthBuffer: buffer,
				cbAuthBuffer: size,
				pszUserName: userNameBuffer,
				pcchMaxUserName: ref userNameSize,
				pszDomainName: domainBuffer,
				pcchMaxDomainame: ref domainSize,
				pszPassword: passwordBuffer,
				pcchMaxPassword: ref passwordSize)) {
				Console.Error.WriteLine("Unable to unpack credential: " + GetLastErrorMessage());
				return false;
			}
			userName = userNameBuffer.ToString();
			password = passwordBuffer.ToString();
			return true;
		}

		static Tuple<int, IntPtr> PackUserNameBuffer(string userName) {
			if(String.IsNullOrWhiteSpace(userName)) {
				return Tuple.Create(0, IntPtr.Zero);
			}
			IntPtr buf = IntPtr.Zero;
			int size = 0;

			// First, calculate size. (buf == IntPtr.Zero)
			var result = NativeMethods.CredPackAuthenticationBuffer(
				dwFlags: 4, // CRED_PACK_GENERIC_CREDENTIALS
				pszUserName: userName,
				pszPassword: String.Empty,
				pPackedCredentials: buf,
				pcbPackedCredentials: ref size);
			Debug.Assert(!result);
			if(Marshal.GetLastWin32Error() != 122) {
				Console.Error.WriteLine("Unable to calculate size of packed authentication buffer: " + GetLastErrorMessage());
				return null;
			}

			buf = Marshal.AllocHGlobal(size);
			if(!NativeMethods.CredPackAuthenticationBuffer(
				dwFlags: 4, // CRED_PACK_GENERIC_CREDENTIALS
				pszUserName: userName,
				pszPassword: String.Empty,
				pPackedCredentials: buf,
				pcbPackedCredentials: ref size)) {
				Console.Error.WriteLine("Unable to pack incoming username: " + GetLastErrorMessage());
				return null;
			}
			return Tuple.Create(size, buf);
		}

		static string SavedPassword(string key) {
			IntPtr credPtr = IntPtr.Zero;
			var ok = NativeMethods.CredRead("ssh:" + key, NativeMethods.CRED_TYPE.GENERIC, 0, out credPtr);
			if(!ok) return null;

			// Decode the credential
			var cred = (NativeMethods.CREDENTIAL)Marshal.PtrToStructure(credPtr, typeof(NativeMethods.CREDENTIAL));
			return Marshal.PtrToStringBSTR(cred.credentialBlob);
		}

		static string GetLastErrorMessage() {
			return new Win32Exception(Marshal.GetLastWin32Error()).Message;
		}

		static void Log(string message) {
			File.AppendAllText(log, message + "\r\n");
		}
	}
}
