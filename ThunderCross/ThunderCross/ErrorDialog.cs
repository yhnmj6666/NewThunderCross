using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderCross
{
	public partial class ErrorDialog : Form
	{
		public ErrorDialog(String s)
		{
			InitializeComponent();
			textBox.Text = s;

			Size tsize = TextRenderer.MeasureText(s, textBox.Font);
			Size border = this.Size - textBox.Size;
			this.Size = tsize + border;
			if (this.Size.Height < 200)
				this.Size = new Size(Size.Width, 200);
			if (this.Size.Width < 300)
				this.Size = new Size(300, Size.Height);
			if (this.Size.Height > 1000)
				this.Size = new Size(Size.Width, 1000);
			if (this.Size.Width >700)
				this.Size = new Size(700, Size.Height);
		}
		
		private void button_Copy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBox.Text, TextDataFormat.UnicodeText);
			button_Copy.Text = "Copied";
		}

		static public void Report(string s)
		{
			ErrorDialog ed = new ErrorDialog(s);
			ed.ShowDialog();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
