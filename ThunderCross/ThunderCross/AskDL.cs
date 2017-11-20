using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteSizeLib;

namespace ThunderCross
{
	partial class AskDL : Form
	{
		public DLAgent RetAgent;
		public AskDL(DLRequest r)
		{
			InitializeComponent();
			textBox_Url.Text = "    "+r.Url;
			textBox_Name.Text = r.Filename;
			textBox_Type.Text = r.ContentType;
			textBox_Size.Text = ByteSize.Parse(r.ContentLength+"B").ToString();
			button_DM.Text = r.DefaultDM;
			switch (r.DefaultDM)
			{
				case "Thunder":
					button_DM.ButtonClick += button_Thunder_Click;
					break;
				case "EagleGet":
					button_DM.ButtonClick += button_EagleGet_Click;
					break;
			}
		}

		private void button_Default_Click(object sender, EventArgs e)
		{
			RetAgent = DLAgent.Default;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button_Thunder_Click(object sender, EventArgs e)
		{
			RetAgent = DLAgent.Thunder;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button_EagleGet_Click(object sender, EventArgs e)
		{
			RetAgent = DLAgent.EagleGet;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.RetAgent = DLAgent.Cancel;
			this.Close();
		}
	}
}
