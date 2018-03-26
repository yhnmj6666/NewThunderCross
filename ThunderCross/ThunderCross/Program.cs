using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.IO.Pipes;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThunderCross
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			if (args.Length > 0)
			{
				switch(args[0].ToLower())
				{
					case "breaked":
						{
							NamedPipeClientStream aPipeClient = new NamedPipeClientStream(args[1]);
							BinaryReader br = new BinaryReader(aPipeClient);
							aPipeClient.Connect(5000);
							string sTask = br.ReadString();
							aPipeClient.Close();
							DLTask dt = JsonConvert.DeserializeObject<DLTask>(sTask);
							dt.Perform();
							break;
						}
					case "fix":
						{
							string thunderexe = args[1];
							string thunderagentdll = args[2];
							string thunderagent64bit = thunderagentdll.ToLower().Replace("thunderagent.dll", "thunderagent64.dll");
							Stack<string> tpaths = new Stack<string>(thunderexe.Split('\\'));
							tpaths.Pop();
							if (tpaths.Peek().ToLower() == "program")
								tpaths.Pop();
							string thunderroot = string.Join("\\", tpaths.Reverse())+"\\";
							string version = FileVersionInfo.GetVersionInfo(thunderexe).FileVersion.Replace(',','.');
							if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess)
							{
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Thunder Network\ThunderOem\thunder_backwnd", "dir", thunderroot, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Thunder Network\ThunderOem\thunder_backwnd", "Path", thunderexe, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Thunder Network\ThunderOem\thunder_backwnd", "instdir", thunderroot, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Thunder Network\ThunderOem\thunder_backwnd", "Version", version, RegistryValueKind.String);
							}
							else
							{
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Thunder Network\ThunderOem\thunder_backwnd", "dir", thunderroot, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Thunder Network\ThunderOem\thunder_backwnd", "Path", thunderexe, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Thunder Network\ThunderOem\thunder_backwnd", "instdir", thunderroot, RegistryValueKind.String);
								Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Thunder Network\ThunderOem\thunder_backwnd", "Version", version, RegistryValueKind.String);
							}
							Process.Start("regsvr32", "/s \"" + thunderagentdll + "\"");
							if (Environment.Is64BitOperatingSystem && File.Exists(thunderagent64bit))
							{
								Process.Start("regsvr32", "/s \"" + thunderagent64bit + "\"");
							}
							else
							{
								MessageBox.Show((IWin32Window)null,Strings.This_copy_of_Thunder_supports_32_bit_only);
							}
							break;
						}
					default:
						{
							Web_ext_Message msg = GetMsg();
							DLRequest req = msg.Dispatch();
							DLReply reply = req.Process();
							SendMsg(reply);
							break;
						}
				}
			}
			else
			{
				WelcomeDialog dialog = new WelcomeDialog();
				dialog.ShowDialog();
			}
		}

		private static Web_ext_Message GetMsg()
		{
			BinaryReader br = new BinaryReader(Console.OpenStandardInput(),Encoding.UTF8);
			int datalen = br.ReadInt32();
			string dat = Encoding.UTF8.GetString(br.ReadBytes(datalen));
			return new Web_ext_Message(datalen, dat);
		}

		private static void SendMsg(DLReply r)
		{
			BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput(), Encoding.UTF8);
			string msg = JsonConvert.SerializeObject(r);
			stdos.Write(msg.Length);
			stdos.Write(msg.ToCharArray());
			stdos.Flush();
		}

	}
}
