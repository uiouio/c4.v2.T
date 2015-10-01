using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;
namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RolesSystem ��ժҪ˵����
	/// </summary>
	public class RolesSystem
	{
		public RolesSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
