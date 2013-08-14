using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace askpass {
	public partial class PasswordPrompt : Form {
		public PasswordPrompt(string key) {
			InitializeComponent();

			passwordLabel.Text = "Password for " + key;
			passwordText.Focus();
		}

		public string Password {
			get {
				return passwordText.Text;
			}
		}

		private void ok_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}
	}
}
