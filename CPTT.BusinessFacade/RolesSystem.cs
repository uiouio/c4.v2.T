using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;
namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RolesSystem 的摘要说明。
	/// </summary>
	public class RolesSystem
	{
		public RolesSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetRolesDuty(int getTeaNumber)
		{
			using ( RolesDataAccess rolesDataAccess = new RolesDataAccess() )
			{
				try
				{
					return rolesDataAccess.GetRolesDuty(getTeaNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}
	}
}
