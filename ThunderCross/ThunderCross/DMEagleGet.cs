using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace ThunderCross
{
	class DMEagleGet : IDownloadManager
	{
		public string Url { get; set; }
		public string ExecutablePath { get { return Registry.LocalMachine.OpenSubKey("EagleGet").GetValue("Path")+ "EagleGet.exe"; } }
		public DMEagleGet(string url)
		{
			Url = url;
		}
		public void Fire()
		{
			Process eg = new Process();
			eg.StartInfo.FileName = ExecutablePath;
			eg.StartInfo.Arguments = @"\S\U" + Url + @"U\";
			eg.Start();
		}
	}
}
