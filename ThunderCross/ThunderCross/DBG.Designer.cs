namespace ThunderCross
{
    partial class DBG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBG));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.alphaLable1 = new AlphaTextBox.AlphaLable();
            this.alphaLable2 = new AlphaTextBox.AlphaLable();
            this.alphaLable6 = new AlphaTextBox.AlphaLable();
            this.alphaLable7 = new AlphaTextBox.AlphaLable();
            this.alphaGroupBox1 = new AlphaGroupBox.AlphaGroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.alphaGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, -25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // alphaLable1
            // 
            this.alphaLable1.BackColor = System.Drawing.Color.Black;
            this.alphaLable1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alphaLable1.ForeColor = System.Drawing.Color.Black;
            this.alphaLable1.Location = new System.Drawing.Point(17, 12);
            this.alphaLable1.Name = "alphaLable1";
            this.alphaLable1.Size = new System.Drawing.Size(355, 31);
            this.alphaLable1.TabIndex = 1;
            this.alphaLable1.TabStop = false;
            this.alphaLable1.Text = "您选择了打开：";
            this.alphaLable1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.alphaLable1.Click += new System.EventHandler(this.alphaLable1_Click);
            // 
            // alphaLable2
            // 
            this.alphaLable2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alphaLable2.Location = new System.Drawing.Point(52, 37);
            this.alphaLable2.Name = "alphaLable2";
            this.alphaLable2.Size = new System.Drawing.Size(259, 29);
            this.alphaLable2.TabIndex = 3;
            this.alphaLable2.TabStop = false;
            this.alphaLable2.Text = "File.txt";
            this.alphaLable2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // alphaLable6
            // 
            this.alphaLable6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alphaLable6.Location = new System.Drawing.Point(52, 57);
            this.alphaLable6.Name = "alphaLable6";
            this.alphaLable6.Size = new System.Drawing.Size(259, 29);
            this.alphaLable6.TabIndex = 7;
            this.alphaLable6.TabStop = false;
            this.alphaLable6.Text = "文件类型：";
            this.alphaLable6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // alphaLable7
            // 
            this.alphaLable7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alphaLable7.Location = new System.Drawing.Point(52, 77);
            this.alphaLable7.Name = "alphaLable7";
            this.alphaLable7.Size = new System.Drawing.Size(259, 29);
            this.alphaLable7.TabIndex = 8;
            this.alphaLable7.TabStop = false;
            this.alphaLable7.Text = "来源：";
            this.alphaLable7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // alphaGroupBox1
            // 
            this.alphaGroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.alphaGroupBox1.Controls.Add(this.comboBox1);
            this.alphaGroupBox1.Controls.Add(this.checkBox1);
            this.alphaGroupBox1.Controls.Add(this.checkedListBox1);
            this.alphaGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alphaGroupBox1.Location = new System.Drawing.Point(17, 112);
            this.alphaGroupBox1.Name = "alphaGroupBox1";
            this.alphaGroupBox1.Size = new System.Drawing.Size(422, 143);
            this.alphaGroupBox1.TabIndex = 9;
            this.alphaGroupBox1.TabStop = false;
            this.alphaGroupBox1.Text = "您希望ThunderCross做什么";
            this.alphaGroupBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(43, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(23, 107);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(196, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "下次下载时保持此配置运行";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "使用火狐下载",
            "使用自选下载器下载"});
            this.checkedListBox1.Location = new System.Drawing.Point(23, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(173, 42);
            this.checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(251, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确认";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(353, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(30, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // DBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(451, 321);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.alphaGroupBox1);
            this.Controls.Add(this.alphaLable7);
            this.Controls.Add(this.alphaLable6);
            this.Controls.Add(this.alphaLable2);
            this.Controls.Add(this.alphaLable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBG";
            this.Text = "ThunderCross";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.alphaGroupBox1.ResumeLayout(false);
            this.alphaGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AlphaTextBox.AlphaLable alphaLable1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AlphaTextBox.AlphaLable alphaLable2;
        private AlphaTextBox.AlphaLable alphaLable6;
        private AlphaTextBox.AlphaLable alphaLable7;
        private AlphaGroupBox.AlphaGroupBox alphaGroupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}