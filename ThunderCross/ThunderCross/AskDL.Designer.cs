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
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.label_filetypesize = new System.Windows.Forms.Label();
			this.label_fileurl = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox_dm = new System.Windows.Forms.ComboBox();
			this.checkBox_saveForSite = new System.Windows.Forms.CheckBox();
			this.checkBox_saveOption = new System.Windows.Forms.CheckBox();
			this.radioButton_external = new System.Windows.Forms.RadioButton();
			this.radioButton_default = new System.Windows.Forms.RadioButton();
			this.picture_icon = new System.Windows.Forms.PictureBox();
			this.textBox1_filename = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picture_icon)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = global::ThunderCross.Strings.You_have_choosen_to_open;
			// 
			// button_OK
			// 
			this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OK.Location = new System.Drawing.Point(259, 299);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 33);
			this.button_OK.TabIndex = 3;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Cancel.Location = new System.Drawing.Point(345, 299);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 33);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = global::ThunderCross.Strings.Cancel;
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// label_filetypesize
			// 
			this.label_filetypesize.AutoSize = true;
			this.label_filetypesize.Location = new System.Drawing.Point(61, 72);
			this.label_filetypesize.Name = "label_filetypesize";
			this.label_filetypesize.Size = new System.Drawing.Size(65, 16);
			this.label_filetypesize.TabIndex = 6;
			this.label_filetypesize.Text = global::ThunderCross.Strings.Which_is;
			// 
			// label_fileurl
			// 
			this.label_fileurl.AutoSize = true;
			this.label_fileurl.Location = new System.Drawing.Point(61, 91);
			this.label_fileurl.Name = "label_fileurl";
			this.label_fileurl.Size = new System.Drawing.Size(47, 16);
			this.label_fileurl.TabIndex = 7;
			this.label_fileurl.Text = global::ThunderCross.Strings.From;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.comboBox_dm);
			this.groupBox1.Controls.Add(this.checkBox_saveForSite);
			this.groupBox1.Controls.Add(this.checkBox_saveOption);
			this.groupBox1.Controls.Add(this.radioButton_external);
			this.groupBox1.Controls.Add(this.radioButton_default);
			this.groupBox1.Location = new System.Drawing.Point(15, 114);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 179);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = global::ThunderCross.Strings.What_should_ThunderCross_do_with_this_file;
			// 
			// comboBox_dm
			// 
			this.comboBox_dm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_dm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_dm.FormattingEnabled = true;
			this.comboBox_dm.Location = new System.Drawing.Point(157, 62);
			this.comboBox_dm.Name = "comboBox_dm";
			this.comboBox_dm.Size = new System.Drawing.Size(242, 24);
			this.comboBox_dm.TabIndex = 3;
			// 
			// checkBox_saveForSite
			// 
			this.checkBox_saveForSite.AutoSize = true;
			this.checkBox_saveForSite.Location = new System.Drawing.Point(51, 132);
			this.checkBox_saveForSite.Name = "checkBox_saveForSite";
			this.checkBox_saveForSite.Size = new System.Drawing.Size(124, 20);
			this.checkBox_saveForSite.TabIndex = 2;
			this.checkBox_saveForSite.Text = global::ThunderCross.Strings.Only_for_this_site;
			this.checkBox_saveForSite.UseVisualStyleBackColor = true;
			// 
			// checkBox_saveOption
			// 
			this.checkBox_saveOption.AutoSize = true;
			this.checkBox_saveOption.Location = new System.Drawing.Point(31, 104);
			this.checkBox_saveOption.Name = "checkBox_saveOption";
			this.checkBox_saveOption.Size = new System.Drawing.Size(320, 20);
			this.checkBox_saveOption.TabIndex = 2;
			this.checkBox_saveOption.Text = global::ThunderCross.Strings.Do_this_automatically_for_files_like_this_from_now_on;
			this.checkBox_saveOption.UseVisualStyleBackColor = true;
			// 
			// radioButton_external
			// 
			this.radioButton_external.AutoSize = true;
			this.radioButton_external.Location = new System.Drawing.Point(31, 63);
			this.radioButton_external.Name = "radioButton_external";
			this.radioButton_external.Size = new System.Drawing.Size(120, 20);
			this.radioButton_external.TabIndex = 1;
			this.radioButton_external.Text = global::ThunderCross.Strings.Download_using_;
			this.radioButton_external.UseVisualStyleBackColor = true;
			// 
			// radioButton_default
			// 
			this.radioButton_default.AutoSize = true;
			this.radioButton_default.Location = new System.Drawing.Point(31, 29);
			this.radioButton_default.Name = "radioButton_default";
			this.radioButton_default.Size = new System.Drawing.Size(139, 20);
			this.radioButton_default.TabIndex = 0;
			this.radioButton_default.Text = global::ThunderCross.Strings.Download_in_Firefox;
			this.radioButton_default.UseVisualStyleBackColor = true;
			// 
			// picture_icon
			// 
			this.picture_icon.Location = new System.Drawing.Point(15, 36);
			this.picture_icon.Name = "picture_icon";
			this.picture_icon.Size = new System.Drawing.Size(32, 32);
			this.picture_icon.TabIndex = 10;
			this.picture_icon.TabStop = false;
			// 
			// textBox1_filename
			// 
			this.textBox1_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1_filename.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1_filename.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1_filename.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.textBox1_filename.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1_filename.Location = new System.Drawing.Point(64, 36);
			this.textBox1_filename.Name = "textBox1_filename";
			this.textBox1_filename.ReadOnly = true;
			this.textBox1_filename.Size = new System.Drawing.Size(255, 16);
			this.textBox1_filename.TabIndex = 11;
			this.textBox1_filename.TabStop = false;
			this.textBox1_filename.Text = "Sample File Name";
			this.textBox1_filename.WordWrap = false;
			// 
			// AskDL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(432, 344);
			this.Controls.Add(this.textBox1_filename);
			this.Controls.Add(this.picture_icon);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label_fileurl);
			this.Controls.Add(this.label_filetypesize);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AskDL";
			this.Text = "AskDL";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picture_icon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Label label_filetypesize;
		private System.Windows.Forms.Label label_fileurl;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox_saveOption;
		private System.Windows.Forms.RadioButton radioButton_external;
		private System.Windows.Forms.RadioButton radioButton_default;
		private System.Windows.Forms.PictureBox picture_icon;
		private System.Windows.Forms.ComboBox comboBox_dm;
		private System.Windows.Forms.TextBox textBox1_filename;
		private System.Windows.Forms.CheckBox checkBox_saveForSite;
	}
}