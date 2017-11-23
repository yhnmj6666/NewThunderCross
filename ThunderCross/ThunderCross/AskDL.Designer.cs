namespace ThunderCross
{
	partial class AskDL
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.button_DM = new ExoticControls.SplitButton();
			this.button_Default = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.textBox_Url = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Name = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_Type = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_Size = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "You have choosen to open:";
			// 
			// button_DM
			// 
			this.button_DM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button_DM.ImageKey = "Normal";
			this.button_DM.Location = new System.Drawing.Point(254, 189);
			this.button_DM.Name = "button_DM";
			this.button_DM.Size = new System.Drawing.Size(85, 33);
			this.button_DM.TabIndex = 2;
			this.button_DM.Text = "SampleDM";
			this.button_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_DM.UseVisualStyleBackColor = true;
			this.button_DM.ContextMenu = new System.Windows.Forms.ContextMenu();
			// 
			// button_Default
			// 
			this.button_Default.Location = new System.Drawing.Point(173, 189);
			this.button_Default.Name = "button_Default";
			this.button_Default.Size = new System.Drawing.Size(75, 33);
			this.button_Default.TabIndex = 3;
			this.button_Default.Text = "Default";
			this.button_Default.UseVisualStyleBackColor = true;
			this.button_Default.Click += new System.EventHandler(this.button_Default_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(345, 189);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 33);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// textBox_Url
			// 
			this.textBox_Url.BackColor = System.Drawing.SystemColors.Control;
			this.textBox_Url.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_Url.Location = new System.Drawing.Point(15, 33);
			this.textBox_Url.Multiline = true;
			this.textBox_Url.Name = "textBox_Url";
			this.textBox_Url.ReadOnly = true;
			this.textBox_Url.Size = new System.Drawing.Size(405, 53);
			this.textBox_Url.TabIndex = 5;
			this.textBox_Url.TabStop = false;
			this.textBox_Url.Text = "SampleUrl";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "File name:";
			// 
			// textBox_Name
			// 
			this.textBox_Name.BackColor = System.Drawing.SystemColors.Control;
			this.textBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_Name.Location = new System.Drawing.Point(76, 93);
			this.textBox_Name.Multiline = true;
			this.textBox_Name.Name = "textBox_Name";
			this.textBox_Name.ReadOnly = true;
			this.textBox_Name.Size = new System.Drawing.Size(344, 14);
			this.textBox_Name.TabIndex = 7;
			this.textBox_Name.TabStop = false;
			this.textBox_Name.Text = "SampleName";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "MIME type:";
			// 
			// textBox_Type
			// 
			this.textBox_Type.BackColor = System.Drawing.SystemColors.Control;
			this.textBox_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_Type.Location = new System.Drawing.Point(76, 113);
			this.textBox_Type.Multiline = true;
			this.textBox_Type.Name = "textBox_Type";
			this.textBox_Type.ReadOnly = true;
			this.textBox_Type.Size = new System.Drawing.Size(335, 14);
			this.textBox_Type.TabIndex = 7;
			this.textBox_Type.TabStop = false;
			this.textBox_Type.Text = "SampleType";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "File size:";
			// 
			// textBox_Size
			// 
			this.textBox_Size.BackColor = System.Drawing.SystemColors.Control;
			this.textBox_Size.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_Size.Location = new System.Drawing.Point(76, 133);
			this.textBox_Size.Multiline = true;
			this.textBox_Size.Name = "textBox_Size";
			this.textBox_Size.ReadOnly = true;
			this.textBox_Size.Size = new System.Drawing.Size(335, 14);
			this.textBox_Size.TabIndex = 7;
			this.textBox_Size.TabStop = false;
			this.textBox_Size.Text = "SampleSize";
			// 
			// AskDL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(432, 234);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_Size);
			this.Controls.Add(this.textBox_Type);
			this.Controls.Add(this.textBox_Name);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_Url);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Default);
			this.Controls.Add(this.button_DM);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AskDL";
			this.Text = "AskDL";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private ExoticControls.SplitButton button_DM;
		private System.Windows.Forms.Button button_Default;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.TextBox textBox_Url;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_Name;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_Type;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_Size;
	}
}