using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// RolesDataAccess 的摘要说明。
	/// </summary>
	public class RolesDataAccess :IDisposable
	{
		private DBCommandWrapper dbCommandWrapper;
		private Database dbRoles = DatabaseFactory.CreateDatabase();
		private string getRolseDutyCommand;
		public RolesDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetRolesDuty(int getTeaNumber)
		{
			return FillRolesDuty(getTeaNumber);
		}

		private DataSet FillRolesDuty(int getTeaNumber)
		{
			getRolseDutyCommand = "GetRolesDuty";
			dbCommandWrapper = dbRoles.GetStoredProcCommandWrapper(getRolseDutyCommand);
			dbCommandWrapper.AddInParameter("@getTeaNumber",DbType.Int32,getTeaNumber);
			return dbRoles.ExecuteDataSet(dbCommandWrapper);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return;
			else
			{
				if ( dbRoles != null )
					dbRoles = null;
			}
		}
	}
}
