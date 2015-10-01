using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// MachinesDA ��ժҪ˵����
	/// </summary>
	public class MachinesDA : IDisposable
	{
		private Database db;

		public MachinesDA()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetMachineAddrList()
		{
			DataSet machineAddrList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetWatchMachineList");

				machineAddrList = db.ExecuteDataSet(dbCom);

				return machineAddrList;
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}		
		}

		public DataSet GetClassMachineAddrList()
		{
			DataSet machineAddrList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetClassMachineList");

				machineAddrList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return machineAddrList;
		}

		public int CreateClassMachine()
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("CreateClassMachine");
				dbCom.AddInParameter("@rowsAffected",DbType.Int32,4);
				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteMachine(int deleteMachineAddr)
		{
			int rowsAffected = 0;;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Deletemachine");
				dbCom.AddInParameter("@machine_address",DbType.Int16,deleteMachineAddr);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int UpdateMachine(int deleteOldMachineAddr,int deleteNewMachineAddr)
		{
			int rowsAffected = 0;;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Updatemachine");
				dbCom.AddInParameter("@oldmachine_address",DbType.Int16,deleteOldMachineAddr);
				dbCom.AddInParameter("@newmachine_address",DbType.Int16,deleteNewMachineAddr);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int InsertMachine(int machineAddr)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Insertmachine");
				dbCom.AddInParameter("@machine_address",DbType.Int16,machineAddr);
				dbCom.AddInParameter("@machine_type",DbType.Int16,0);
				dbCom.AddInParameter("@machine_volumn",DbType.Int16,70);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int InsertClassMachine(int machineAddr,int machineVolumn)
		{
			
			int rowsAffected = 0;;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Insertmachine");
				dbCom.AddInParameter("@machine_address",DbType.Int16,machineAddr);
				dbCom.AddInParameter("@machine_type",DbType.Int16,1);
				dbCom.AddInParameter("@machine_volumn",DbType.Int16,machineVolumn);
				 dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}
		#region IDisposable ��Ա

		public void Dispose()
		{
			// TODO:  ��� MachinesDA.Dispose ʵ��
			if(db != null)
			{
				db = null;
			}

			GC.SuppressFinalize(true);
		}

		#endregion
	}
}
