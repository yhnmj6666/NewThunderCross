using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.IO;

namespace ThunderCross
{
	public partial class WelcomeDialog : Form
	{
		public WelcomeDialog()
		{
			InitializeComponent();
			if (!CheckInstallation())
			{
				button_Install.Enabled = true;
			}
			else
			{
				button_Uninstall.Enabled = true;
			}
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
				ErrorDialog.Report(e.Message + "\n" + e.StackTrace);
			}
			return false;
		}

		private static bool Uninstalltion()
		{
			File.Delete(Strings.Config_json);
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla").OpenSubKey("NativeMessagingHosts", writable: true);
			if (key == null)
				return false;
			key.DeleteSubKey("ThunderCross");
			key.Close();
			return true;
		}

		private static bool CheckInstallation()
		{
			try
			{
				if (File.Exists(Strings.Config_json) &&
					Environment.CurrentDirectory + @"\" + Strings.Config_json ==
					Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Mozilla").
					OpenSubKey("NativeMessagingHosts").OpenSubKey("ThunderCross").GetValue(null).ToString())
				{
					return true; //installed
				}
				else
					return false; //not installed
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void button_Install_Click(object sender, EventArgs e)
		{
			if(Installation())
			{
				button_Install.Enabled = false;
				button_Uninstall.Enabled = true;
			}
			else
			{
				MessageBox.Show(Strings.Install_fail);
			}
		}

		private void button_Uninstall_Click(object sender, EventArgs e)
		{
			if (Uninstalltion())
			{
				button_Install.Enabled = true;
				button_Uninstall.Enabled = false;
			}
		}
	}
}
