using System;
using System.Windows.Forms;

namespace ThunderCross
{
	class DLReply
	{
		public readonly string Choice;
		public string AddtionInfo;
		public bool Save = false;
		public string Host = null;

		public DLReply(DLAgent a, bool save = false, string host = null)
		{
			switch (a)
			{
				case DLAgent.CheckDM:
					Choice = a.ToString();
					AddtionInfo = "";
					foreach (var dm in DownloadManager.DMList)
					{
						if (((IDownloadManager)Activator.CreateInstance(Type.GetType("ThunderCross.DM" + dm), true)).Valid())
						{
							AddtionInfo += (dm + ": " + Strings.Ready +"\n");
						}
						else
						{
							AddtionInfo += (dm + ": " + Strings.Failed +"\n");
						}
					}
					break;
				case DLAgent.SelectDM:
					Choice = a.ToString();
					{
						OpenFileDialog openFile = new OpenFileDialog();
						openFile.CheckFileExists = true;
						openFile.CheckPathExists = true;
						openFile.DefaultExt = "exe";
						openFile.Filter = "Executable files(*.exe) | *.exe";
						if (openFile.ShowDialog() == DialogResult.OK)
							AddtionInfo = openFile.FileName;
					}
					break;
				case DLAgent.Version:
					Choice = a.ToString();
					AddtionInfo = typeof(Program).Assembly.GetName().Version.ToString();
					break;
				case DLAgent.Cancel:
				case DLAgent.Default:
					Choice = a.ToString();
					break;
				case DLAgent.EagleGet:
				case DLAgent.Thunder:
				case DLAgent.Idm:
				case DLAgent.Customized:
					Choice = @"External";
					break;
				default:
					Choice = @"error!!";
					break;
			}
			if (save && (a==DLAgent.Default || (int)a>=5))//if a is an external dm
			{
				Save = save;
				Host = host;
			}
		}
	}
}