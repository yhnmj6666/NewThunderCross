namespace ThunderCross
{
	partial class WelcomeDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button_Install = new System.Windows.Forms.Button();
			this.button_Uninstall = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_FIx = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Install
			// 
			this.button_Install.Enabled = false;
			this.button_Install.Location = new System.Drawing.Point(12, 12);
			this.button_Install.Name = "button_Install";
			this.button_Install.Size = new System.Drawing.Size(126, 69);
			this.button_Install.TabIndex = 0;
			this.button_Install.Text = "Install";
			this.button_Install.UseVisualStyleBackColor = true;
			this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
			// 
			// button_Uninstall
			// 
			this.button_Uninstall.Enabled = false;
			this.button_Uninstall.Location = new System.Drawing.Point(146, 12);
			this.button_Uninstall.Name = "button_Uninstall";
			this.button_Uninstall.Size = new System.Drawing.Size(126, 69);
			this.button_Uninstall.TabIndex = 0;
			this.button_Uninstall.Text = "Uninstall";
			this.button_Uninstall.UseVisualStyleBackColor = true;
			this.button_Uninstall.Click += new System.EventHandler(this.button_Uninstall_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.button_FIx);
			this.groupBox1.Location = new System.Drawing.Point(13, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(259, 253);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Fixing";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(6, 214);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(247, 33);
			this.button2.TabIndex = 2;
			this.button2.Text = "Try Fix it!";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(178, 161);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 163);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(166, 20);
			this.textBox1.TabIndex = 1;
			// 
			// button_FIx
			// 
			this.button_FIx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_FIx.Location = new System.Drawing.Point(7, -518);
			this.button_FIx.Name = "button_FIx";
			this.button_FIx.Size = new System.Drawing.Size(0, 33);
			this.button_FIx.TabIndex = 0;
			this.button_FIx.Text = "Try Fix it!";
			this.button_FIx.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(6, 74);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(246, 21);
			this.comboBox1.TabIndex = 3;
			// 
			// WelcomeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 353);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button_Uninstall);
			this.Controls.Add(this.button_Install);
			this.Name = "WelcomeDialog";
			this.Text = "Welcome";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_Install;
		private System.Windows.Forms.Button button_Uninstall;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button_FIx;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}