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
			this.saveCheckbox = new System.Windows.Forms.CheckBox();
			this.badPassLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(236, 142);
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
			this.cancel.Location = new System.Drawing.Point(317, 142);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 25);
			this.cancel.TabIndex = 3;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.saveCheckbox);
			this.panel1.Controls.Add(this.badPassLabel);
			this.panel1.Controls.Add(this.passwordLabel);
			this.panel1.Controls.Add(this.passwordText);
			this.panel1.Controls.Add(this.label1);
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Location = new System.Drawing.Point(-5, -8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(415, 144);
			this.panel1.TabIndex = 2;
			// 
			// saveCheckbox
			// 
			this.saveCheckbox.AutoSize = true;
			this.saveCheckbox.Location = new System.Drawing.Point(21, 113);
			this.saveCheckbox.Name = "saveCheckbox";
			this.saveCheckbox.Size = new System.Drawing.Size(102, 17);
			this.saveCheckbox.TabIndex = 3;
			this.saveCheckbox.Text = "Save password";
			this.saveCheckbox.UseVisualStyleBackColor = true;
			// 
			// badPassLabel
			// 
			this.badPassLabel.AutoSize = true;
			this.badPassLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.badPassLabel.ForeColor = System.Drawing.Color.Red;
			this.badPassLabel.Location = new System.Drawing.Point(18, 41);
			this.badPassLabel.Name = "badPassLabel";
			this.badPassLabel.Size = new System.Drawing.Size(137, 15);
			this.badPassLabel.TabIndex = 2;
			this.badPassLabel.Text = "Bad password, try again";
			this.badPassLabel.Visible = false;
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordLabel.Location = new System.Drawing.Point(18, 59);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(217, 15);
			this.passwordLabel.TabIndex = 0;
			this.passwordLabel.Text = "Password for /c/Users/Luke/.ssh//id_rsa";
			// 
			// passwordText
			// 
			this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.passwordText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordText.ForeColor = System.Drawing.SystemColors.WindowText;
			this.passwordText.Location = new System.Drawing.Point(19, 82);
			this.passwordText.Name = "passwordText";
			this.passwordText.Size = new System.Drawing.Size(378, 23);
			this.passwordText.TabIndex = 1;
			this.passwordText.UseSystemPasswordChar = true;
			this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
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
			this.ClientSize = new System.Drawing.Size(404, 179);
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
		private System.Windows.Forms.Label badPassLabel;
		private System.Windows.Forms.CheckBox saveCheckbox;
	}
}