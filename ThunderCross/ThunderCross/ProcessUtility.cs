using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	static class ProcessUtility
	{
		public const int CW_USEDEFAULT = unchecked((int)0x80000000);
		public const int CREATE_BREAKAWAY_FROM_JOB = unchecked((int)0x01000000);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STARTUPINFO
		{
			public Int32 cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public Int32 dwX;
			public Int32 dwY;
			public Int32 dwXSize;
			public Int32 dwYSize;
			public Int32 dwXCountChars;
			public Int32 dwYCountChars;
			public Int32 dwFillAttribute;
			public Int32 dwFlags;
			public Int16 wShowWindow;
			public Int16 cbReserved2;
			public IntPtr lpReserved2;
			public IntPtr hStdInput;
			public IntPtr hStdOutput;
			public IntPtr hStdError;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STARTUPINFOEX
		{
			public STARTUPINFO StartupInfo;
			public IntPtr lpAttributeList;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct SECURITY_ATTRIBUTES
		{
			public int nLength;
			public IntPtr lpSecurityDescriptor;
			public int bInheritHandle;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct PROCESS_INFORMATION
		{
			public IntPtr hProcess;
			public IntPtr hThread;
			public int dwProcessId;
			public int dwThreadId;
		}

		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool CreateProcess(
		   string lpApplicationName,
		   string lpCommandLine,
		   ref SECURITY_ATTRIBUTES lpProcessAttributes,
		   ref SECURITY_ATTRIBUTES lpThreadAttributes,
		   bool bInheritHandles,
		   uint dwCreationFlags,
		   IntPtr lpEnvironment,
		   string lpCurrentDirectory,
		   [In] ref STARTUPINFO lpStartupInfo,
		   out PROCESS_INFORMATION lpProcessInformation);

		public static void CreateProcessBreakFromJob(string command)
		{
			STARTUPINFO si=new STARTUPINFO();
			si.cb = Marshal.SizeOf(si);
			PROCESS_INFORMATION pi=new PROCESS_INFORMATION();
			SECURITY_ATTRIBUTES pa = new SECURITY_ATTRIBUTES();
			SECURITY_ATTRIBUTES ta = new SECURITY_ATTRIBUTES();
			bool result=CreateProcess(null, command, ref pa, ref ta, false, CREATE_BREAKAWAY_FROM_JOB, (IntPtr)0, null, ref si, out pi);
			
		}
	}
}
