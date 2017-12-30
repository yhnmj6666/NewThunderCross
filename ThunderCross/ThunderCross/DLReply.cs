﻿using System;
using System.Windows.Forms;

namespace ThunderCross
{
	class DLReply
	{
		public readonly string Choice;
		public string AddtionInfo;
		public bool Save = false;
		public bool SaveForSite = false;

		public DLReply(DLAgent a)
		{
			switch(a)
			{
				case DLAgent.CheckDM:
					Choice = a.ToString();
					AddtionInfo = "";
					foreach (var dm in DownloadManager.DMList)
					{
						if (((IDownloadManager)Activator.CreateInstance(Type.GetType("ThunderCross.DM" + dm), true)).Valid())
						{
							AddtionInfo += (dm + ": " + "Ready\n");
						}
						else
						{
							AddtionInfo += (dm + ": " + "Failed\n");
						}
					}
					break;
				case DLAgent.SelectDM:
					Choice = a.ToString();
					{
						Application.EnableVisualStyles();
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
		}

		internal void SaveDownload(bool saveForSiteOnly)
		{
			Save = true;
			SaveForSite = saveForSiteOnly;
		}
	}
}
