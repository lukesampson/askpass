namespace askpass {
	partial class PasswordPrompt {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(231, 107);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 25);
			this.ok.TabIndex = 2;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(317, 107);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 25);
			this.cancel.TabIndex = 3;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.passwordLabel);
			this.panel1.Controls.Add(this.passwordText);
			this.panel1.Controls.Add(this.label1);
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Location = new System.Drawing.Point(-5, -8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(415, 106);
			this.panel1.TabIndex = 2;
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(18, 40);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(208, 13);
			this.passwordLabel.TabIndex = 0;
			this.passwordLabel.Text = "Password for /c/Users/Luke/.ssh//id_rsa";
			// 
			// passwordText
			// 
			this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.passwordText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordText.Location = new System.Drawing.Point(19, 66);
			this.passwordText.Name = "passwordText";
			this.passwordText.Size = new System.Drawing.Size(378, 23);
			this.passwordText.TabIndex = 1;
			this.passwordText.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(17, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(191, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "SSH Private Key Password";
			// 
			// PasswordPrompt
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(404, 142);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "PasswordPrompt";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "SSH";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox passwordText;
		private System.Windows.Forms.Label passwordLabel;
	}
}