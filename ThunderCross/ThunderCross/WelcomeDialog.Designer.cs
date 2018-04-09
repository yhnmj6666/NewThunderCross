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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeDialog));
			this.button_Install = new System.Windows.Forms.Button();
			this.button_Uninstall = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button_tryFixIt = new System.Windows.Forms.Button();
			this.button_browser2 = new System.Windows.Forms.Button();
			this.button_browse1 = new System.Windows.Forms.Button();
			this.textBox_thunderExePath = new System.Windows.Forms.TextBox();
			this.textBox_thunderAgentdll = new System.Windows.Forms.TextBox();
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
			this.button_Install.Text = global::ThunderCross.Strings.Install;
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
			this.button_Uninstall.Text = global::ThunderCross.Strings.Uninstall;
			this.button_Uninstall.UseVisualStyleBackColor = true;
			this.button_Uninstall.Click += new System.EventHandler(this.button_Uninstall_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button_tryFixIt);
			this.groupBox1.Controls.Add(this.button_browser2);
			this.groupBox1.Controls.Add(this.button_browse1);
			this.groupBox1.Controls.Add(this.textBox_thunderExePath);
			this.groupBox1.Controls.Add(this.textBox_thunderAgentdll);
			this.groupBox1.Location = new System.Drawing.Point(13, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(259, 218);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = global::ThunderCross.Strings.Fixing;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = global::ThunderCross.Strings.ThunderAgent_dll_Path;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = global::ThunderCross.Strings.Thunder_exe_Path;
			// 
			// button_tryFixIt
			// 
			this.button_tryFixIt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_tryFixIt.Location = new System.Drawing.Point(5, 179);
			this.button_tryFixIt.Name = "button_tryFixIt";
			this.button_tryFixIt.Size = new System.Drawing.Size(247, 33);
			this.button_tryFixIt.TabIndex = 2;
			this.button_tryFixIt.Text = global::ThunderCross.Strings.Try_Fix;
			this.button_tryFixIt.UseVisualStyleBackColor = true;
			this.button_tryFixIt.Click += new System.EventHandler(this.button_tryFixIt_Click);
			// 
			// button_browser2
			// 
			this.button_browser2.Location = new System.Drawing.Point(177, 106);
			this.button_browser2.Name = "button_browser2";
			this.button_browser2.Size = new System.Drawing.Size(75, 23);
			this.button_browser2.TabIndex = 0;
			this.button_browser2.Text = global::ThunderCross.Strings.browse;
			this.button_browser2.UseVisualStyleBackColor = true;
			this.button_browser2.Click += new System.EventHandler(this.button_browse2_Click);
			// 
			// button_browse1
			// 
			this.button_browse1.Location = new System.Drawing.Point(177, 31);
			this.button_browse1.Name = "button_browse1";
			this.button_browse1.Size = new System.Drawing.Size(75, 23);
			this.button_browse1.TabIndex = 0;
			this.button_browse1.Text = global::ThunderCross.Strings.browse;
			this.button_browse1.UseVisualStyleBackColor = true;
			this.button_browse1.Click += new System.EventHandler(this.button_browse1_Click);
			// 
			// textBox_thunderExePath
			// 
			this.textBox_thunderExePath.Location = new System.Drawing.Point(6, 60);
			this.textBox_thunderExePath.Name = "textBox_thunderExePath";
			this.textBox_thunderExePath.Size = new System.Drawing.Size(246, 20);
			this.textBox_thunderExePath.TabIndex = 1;
			// 
			// textBox_thunderAgentdll
			// 
			this.textBox_thunderAgentdll.Location = new System.Drawing.Point(6, 135);
			this.textBox_thunderAgentdll.Name = "textBox_thunderAgentdll";
			this.textBox_thunderAgentdll.Size = new System.Drawing.Size(246, 20);
			this.textBox_thunderAgentdll.TabIndex = 1;
			// 
			// WelcomeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 318);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button_Uninstall);
			this.Controls.Add(this.button_Install);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WelcomeDialog";
			this.Text = global::ThunderCross.Strings.Welcome_ThunderCross;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_Install;
		private System.Windows.Forms.Button button_Uninstall;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button_tryFixIt;
		private System.Windows.Forms.Button button_browse1;
		private System.Windows.Forms.TextBox textBox_thunderAgentdll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_thunderExePath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button_browser2;
	}
}