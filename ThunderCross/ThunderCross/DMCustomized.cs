using System;
using System.Diagnostics;
using System.IO;

namespace ThunderCross
{
	class DMCustomized : IDownloadManager
	{
		public string Url { get; set; }
		public string FileName { get; set; }
		public string Refer { get; set; }
		public string Cookie { get; set; }

		public string Name { get; set; }
		public string ExecutablePath { get; set; }
		public string Arguments { get; set; }

		public void Fire()
		{
			Process dm = new Process();
			dm.StartInfo.FileName = ExecutablePath;
			dm.StartInfo.Arguments = ParseArguments();
			dm.Start();
		}

		private string ParseArguments()
		{
			return Arguments.Replace("[URL]", Url)
				.Replace("[FILENAME]", FileName)
			//	.Replace("[REFER]", Refer)
			//	.Replace("[COOKIE]", Cookie)
				;
		}

		public bool Valid()
		{
			return File.Exists(ExecutablePath);
		}
	}
}
