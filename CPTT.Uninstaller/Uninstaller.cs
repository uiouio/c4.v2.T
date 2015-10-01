using System;
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

namespace CPTT.Uninstaller
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class Uninstaller
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		
		private static string _installPath = string.Empty;

		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: 在此处添加代码以启动应用程序
			//

			try
			{
				CloseAutoService();
				Thread.Sleep(2000);
				DetachDb();
				Thread.Sleep(2000);
				Uninstall();
			}
			catch(Exception ex)
			{
				string s = ex.Message;
				Console.WriteLine("卸载失败，您可以通过控制面板的添加删除程序试试");
				Console.Read();
			}
		}

		private static void CloseAutoService()
		{
			string processName = "CPTT.WinUI";
			foreach (Process thisproc in Process.GetProcessesByName(processName)) 
			{
				if(!thisproc.CloseMainWindow())
				{
					thisproc.Kill();
				}
			}

			ServiceController AutoService = new ServiceController("CPTT4.0AutoService");
			if(AutoService.Status.Equals(ServiceControllerStatus.Running))
			{
				AutoService.Stop();
			}
		}

		private static void DetachDb()
		{
			Process scriptProcess = new Process();
			string detachScript = string.Format(@"exec sp_detach_db N'CTPPDB'");
			scriptProcess.StartInfo.FileName = "osql.exe";
			scriptProcess.StartInfo.Arguments = string.Format(@"-E");
			scriptProcess.StartInfo.UseShellExecute = false;
			scriptProcess.StartInfo.RedirectStandardInput = true;
			scriptProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			scriptProcess.Start();
			scriptProcess.StandardInput.WriteLine(detachScript);
			scriptProcess.StandardInput.WriteLine("go");
			scriptProcess.StandardInput.WriteLine("exit");
			scriptProcess.WaitForExit();
		}

		private static void Uninstall()
		{
			if (System.Environment.OSVersion.ToString().IndexOf("NT 5") == -1)
			{
				throw new Exception();
			}
			else
			{
				StringBuilder sbProductCode = new StringBuilder(39); 
				string productCode = string.Empty;
				int iIdx = 0;
				while (0 == MsiEnumProducts(iIdx++, sbProductCode))
				{
					Int32 productNameLen = 512;
					StringBuilder sbProductName = new StringBuilder(productNameLen);
					MsiGetProductInfo(sbProductCode.ToString(), "ProductName", sbProductName, ref productNameLen);
					if (sbProductName.ToString().Equals("创智智能晨检网络管理系统"))
					{
						productCode = sbProductCode.ToString();
						break;
					}
				}
			
				if (productCode.Length != 0)
				{
					Process uninstallProc = new Process();
					uninstallProc.StartInfo.FileName = "msiexec";
					uninstallProc.StartInfo.Arguments = @"/X" + productCode + " /quiet";
					//uninstallProc.StartInfo.Arguments = @"/X{05F786B3-E1F3-47AD-909B-6F784F4CEFD0}";
					//uninstallProc.StartInfo.Arguments = @"/X{9E926BC5-19EC-4762-8F7B-A6BE13ACA11D}";
					uninstallProc.StartInfo.UseShellExecute = false;
					uninstallProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					uninstallProc.Start();
					uninstallProc.WaitForExit();
				}
			}
		}

		[DllImport("msi.dll", CharSet = CharSet.Unicode)]
		static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);
		[DllImport("msi.dll", SetLastError = true)]
		static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf); 
	}
}
