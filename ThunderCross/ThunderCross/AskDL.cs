using System;
using System.Windows.Forms;
using ByteSizeLib;
using System.IO;
using System.Globalization;

namespace ThunderCross
{
	partial class AskDL : Form
	{
		public DLAgent RetAgent;
		public bool SaveDownload { get { return checkBox_saveOption.Checked; } }
		public string SavedHost { get { return checkBox_saveForSite.Checked?comboBox_Host.SelectedItem.ToString():null; } }

		HttpMethod method;
		public AskDL(DLRequest r)
		{
			InitializeComponent();
			//mod title
			this.Text += (": " + r.Filename);
			//save method for further warning(thunder X POST
			method = r.Method;
			//set font for chinese env. since 宋体 is to ugly.
			if (CultureInfo.CurrentCulture.Equals(CultureInfo.GetCultureInfo("zh-cn")))
				this.Font = new System.Drawing.Font("微软雅黑", 10);
			//whether show in the center of the screen
			if(r.ShowCenter)
			{
				this.StartPosition = FormStartPosition.CenterScreen;
			}
			//show host
			label_fileurl.Text = label_fileurl.Text + new Uri(r.Url).Host;
			//filename.
			textBox1_filename.Text = r.Filename;
			//show file size in most suitable unit.
			label_filetypesize.Text = label_filetypesize.Text + string.Format("{0} ({1})",r.ContentType,ByteSize.Parse(r.ContentLength + "B").ToString());
			//load icon from system according to extension
			picture_icon.Image = Etier.IconHelper.IconReader.GetFileIcon(Path.GetExtension(r.Filename), Etier.IconHelper.IconReader.IconSize.Large, false).ToBitmap();
			//load default dm
			if (r.DefaultDM == DLAgent.Customized.ToString())
			{
				comboBox_dm.Items.Add(string.Format("{0} ({1})",r.CustomizedDM[0].Name, DLAgent.Customized.ToString()));
			}
			else
			{
				comboBox_dm.Items.Add(Enum.Parse(typeof(DLAgent), r.DefaultDM));
			}
			comboBox_dm.SelectedIndex = 0;
			radioButton_external.Checked = true;
			//load other available dm
			foreach (var dm in DownloadManager.DMList)
			{
				if (dm!=r.DefaultDM && ((IDownloadManager)Activator.CreateInstance(Type.GetType("ThunderCross.DM"+dm),true)).Valid())
				{
					comboBox_dm.Items.Add(Enum.Parse(typeof(DLAgent), dm));
				}
			}
			//set hosts for "save option"
			string[] hostpart = new Uri(r.Url).Host.Split('.');
			for(int i=hostpart.Length-1;i>=0;i--)
			{
				comboBox_Host.Items.Add(string.Join(".", hostpart, i, hostpart.Length - i));
			}
			comboBox_Host.SelectedIndex = hostpart.Length - 1;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.RetAgent = DLAgent.Cancel;
			this.Close();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			if (radioButton_external.Checked)
			{
				if (comboBox_dm.SelectedItem.ToString().EndsWith("(" + DLAgent.Customized.ToString() + ")"))
					RetAgent = DLAgent.Customized;
				else
				{
					if (method == HttpMethod.POST && comboBox_dm.SelectedItem.ToString() == "Thunder" &&
						MessageBox.Show(this, Strings.Thunder_is_not_capable_with_POST_method, Strings.Warning, MessageBoxButtons.YesNo) != DialogResult.Yes)
						return;
					else
						RetAgent = (DLAgent)comboBox_dm.SelectedItem;
				}
			}
			else if (radioButton_default.Checked)
				RetAgent = DLAgent.Default;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void checkBox_saveOption_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_saveOption.Checked)
			{
				checkBox_saveForSite.Enabled = true;
				comboBox_Host.Enabled = true;
			}
			else
			{
				checkBox_saveForSite.Enabled = false;
				comboBox_Host.Enabled = false;
			}
		}

		private void comboBox_Host_SelectedIndexChanged(object sender, EventArgs e)
		{
			checkBox_saveForSite.Enabled = true;
		}
	}
}
