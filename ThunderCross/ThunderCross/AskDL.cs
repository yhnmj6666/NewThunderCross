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
	public partial class AskDL : Form
	{
		public DLAgent RetAgent;
		public AskDL()
		{
			InitializeComponent();
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

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
