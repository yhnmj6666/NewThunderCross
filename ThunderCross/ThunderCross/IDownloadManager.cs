using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	interface IDownloadManager
	{
		string Url { get; set; }
		string FileName { get; set; }
		string Refer { get; set; }
		string Cookie { get; set; }
		void Fire();
		bool Valid();
	}
	
	static class DownloadManager
	{
		public static string[] DMList => new string[] { "Thunder", "EagleGet","Idm" };
	}
}
