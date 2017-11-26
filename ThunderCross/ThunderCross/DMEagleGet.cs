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
		/*
		 * EagleGet Commandline Arguments:
		 * "C:\Program Files (x86)\EagleGet\EagleGet.exe" \S\Ud.url&EGet_fname=d.fileNameU\ \Rd.refferR\ \Cd.cookieC\ \Hd.headerH\ \Pd.postDataP\ \Gwindow.navigator.userAgentG\
		 **/
		public string Url { get; set; }
		public string FileName { get; set; }
		public string Refer { get; set; }
		public string Cookie { get; set; }
		public string Header { get; set; }
		public string PostData { get; set; }
		public string UserAgent { get; set; }
		public string ExecutablePath { get { return Environment.Is64BitProcess?
					(Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Wow6432Node").OpenSubKey("EagleGet").GetValue("Path")+ "\\EagleGet.exe"):
					(Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("EagleGet").GetValue("Path") + "\\EagleGet.exe"); } }
		public DMEagleGet() { }
		public void Fire()
		{
			Process eg = new Process();
			eg.StartInfo.FileName = ExecutablePath;
			eg.StartInfo.Arguments = @"\S\U" + Url + @"U\";
			eg.Start();
		}
		public bool Valid()
		{
			try { string s=ExecutablePath; } catch(Exception) { return false; }
			return true;
		}
	}
}
