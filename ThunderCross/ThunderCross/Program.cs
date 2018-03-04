using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.IO.Pipes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;


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
				CheckInstallation();
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

		private static bool Installation()
		{
			//{
			//	"name": "ThunderCross",
			//	"description": "Thunder invoker binary",
			//	"path": "U:/Projects/FireFox/NewThunderCross/ThunderCross/ThunderCross/bin/x64/Debug/ThunderCross.exe",
			//	"type": "stdio",
			//	"allowed_extensions": [ "Thunder@Cross" ]
			//}
			JObject jObject = new JObject
			{
				{ "name", "ThunderCross" },
				{ "description", "Thunder invoker binary" },
				{ "path", Application.ExecutablePath },
				{ "type", "stdio" },
				{ "allowed_extensions", JToken.FromObject(new string[] { "Thunder@Cross" }) }
			};
			StreamWriter config_json = new StreamWriter(Strings.Config_json, append: false);
			config_json.Write(jObject.ToString());
			config_json.Flush();
			string configPath = Environment.CurrentDirectory + @"\" + Strings.Config_json;
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey("Software");
				if (key != null)
				{
					key = key.OpenSubKey("Mozilla");
					if (key == null)
					{
						key = Registry.CurrentUser.OpenSubKey("Software", writable: true);
						key.CreateSubKey("Mozilla");
						key.Close();
						key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla");
					}
					key = key.OpenSubKey("NativeMessagingHosts");
					if (key == null)
					{
						key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla", writable: true);
						key.CreateSubKey("NativeMessagingHosts");
						key.Close();
					}
					key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla").OpenSubKey("NativeMessagingHosts", writable: true);
					RegistryKey tckey = key.CreateSubKey("ThunderCross");
					tckey.SetValue(null, configPath);
					key.Close();
					tckey.Close();
					return true;
				}
			}
			catch (System.Security.SecurityException e)
			{
				ErrorDialog.Report(e.Message +"\n" + e.StackTrace);
			}
			return false;
		}

		private static bool Uninstalltion()
		{
			File.Delete(Strings.Config_json);
			RegistryKey key=Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla").OpenSubKey("NativeMessagingHosts", writable: true);
			if (key == null)
				return false;
			key.DeleteSubKey("ThunderCross");
			key.Close();
			return true;
		}

		private static void CheckInstallation()
		{
			if (File.Exists(Strings.Config_json) &&
				Environment.CurrentDirectory + @"\" + Strings.Config_json ==
				Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla").
				OpenSubKey("NativeMessagingHosts").OpenSubKey("ThunderCross").GetValue(null).ToString())
			{
				if (MessageBox.Show(Strings.Uninstall, "ThunderCross", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (Uninstalltion() == true)
						MessageBox.Show(Strings.Uninstall_success);
				}
			}
			else if (MessageBox.Show(Strings.Install, "ThunderCross", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (Installation() == true)
					MessageBox.Show(Strings.Install_successful);
				else
					MessageBox.Show(Strings.Install_fail);
			}
		}
	}
}
