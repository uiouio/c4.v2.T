using System;
using System.Data;
using System.Collections;
using CPTT.DataAccess;
using CPTT.SystemFramework;
using Microsoft.Win32;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// HardWareAuthentication 的摘要说明。
	/// </summary>
	public class HardWareAuthentication
	{
		private static volatile ArrayList _authorizedHardWare = new ArrayList();
		private static volatile ArrayList _unAuthorizedHardWare = new ArrayList();
		public HardWareAuthentication()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static ArrayList GetAuthorizedHardWare()
		{
			_authorizedHardWare.Sort();
			return _authorizedHardWare;
		}

		public static void SetAuthorizedHardWare(int getValue)
		{
			if ( !_authorizedHardWare.Contains(getValue) ) _authorizedHardWare.Add(getValue); 
		}

		public static ArrayList GetUnAuthorizedHardWare()
		{
			DataSet dsMachineList = new MachinesDA().GetMachineAddrList();

			if ( dsMachineList != null )
			{
				if ( dsMachineList.Tables[0].Rows.Count > 0 )
				{
					foreach ( DataRow dr in dsMachineList.Tables[0].Rows )
						_unAuthorizedHardWare.Add(Convert.ToInt32(dr["machine_address"]));

				
					_unAuthorizedHardWare.Sort();

					return _unAuthorizedHardWare;
				}
				else return null;
			}
			else return null;

		}

		public static void SetUnAuthorizedHardWare(int getValue)
		{
			if ( _unAuthorizedHardWare.Contains(getValue) ) _unAuthorizedHardWare.Remove(getValue);
		}

		public static int GetDaysValid
		{
			get
			{
				try
				{
					RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("Software");
					RegistryKey winSysDataKey = softwareKey.OpenSubKey("WindowsDataSystem");
	
					if ( winSysDataKey == null ) return -1;
					else
					{
						RegistryKey ctppKey = winSysDataKey.OpenSubKey("Corporation");
	
						if ( ctppKey == null ) return -1;
						else return Convert.ToInt32(ctppKey.GetValue("RegisterDays"));
					}

				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}
	}
}
