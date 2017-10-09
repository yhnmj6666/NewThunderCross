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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_Thunder = new System.Windows.Forms.Button();
			this.button_Default = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
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
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(157, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(263, 20);
			this.textBox1.TabIndex = 1;
			// 
			// button_Thunder
			// 
			this.button_Thunder.Location = new System.Drawing.Point(264, 102);
			this.button_Thunder.Name = "button_Thunder";
			this.button_Thunder.Size = new System.Drawing.Size(75, 23);
			this.button_Thunder.TabIndex = 2;
			this.button_Thunder.Text = "Thunder";
			this.button_Thunder.UseVisualStyleBackColor = true;
			this.button_Thunder.Click += new System.EventHandler(this.button_Thunder_Click);
			// 
			// button_Default
			// 
			this.button_Default.Location = new System.Drawing.Point(183, 102);
			this.button_Default.Name = "button_Default";
			this.button_Default.Size = new System.Drawing.Size(75, 23);
			this.button_Default.TabIndex = 3;
			this.button_Default.Text = "Default";
			this.button_Default.UseVisualStyleBackColor = true;
			this.button_Default.Click += new System.EventHandler(this.button_Default_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(345, 102);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// AskDL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(432, 137);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Default);
			this.Controls.Add(this.button_Thunder);
			this.Controls.Add(this.textBox1);
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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button_Thunder;
		private System.Windows.Forms.Button button_Default;
		private System.Windows.Forms.Button button_Cancel;
	}
}