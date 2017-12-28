using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
					Choice = "CkeckDM";
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
				case DLAgent.Version:
					Choice = @"Version";
					AddtionInfo = typeof(Program).Assembly.GetName().Version.ToString();
					break;
				case DLAgent.Cancel:
					Choice = @"Canceled";
					break;
				case DLAgent.Default:
					Choice = @"Default";
					break;
				case DLAgent.EagleGet:
				case DLAgent.Thunder:
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
