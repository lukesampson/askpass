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
		public PasswordPrompt(string key, bool badPass) {
			InitializeComponent();

			passwordLabel.Text = "Password for " + key;
			passwordText.Focus();
			if(badPass) { badPassLabel.Visible = true; }
		}

		public string Password {
			get { return passwordText.Text; }
		}

		public bool Save {
			get { return saveCheckbox.Checked; }
		}

		private void ok_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void passwordText_TextChanged(object sender, EventArgs e) {
			badPassLabel.Visible = false;
		}
	}
}
