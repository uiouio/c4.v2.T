using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// FlowStatesDataAccess ��ժҪ˵����
	/// </summary>
	public class FlowStatesDataAccess : IDisposable
	{
		private Database db;
		public FlowStatesDataAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�

			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetStuState()
		{
			DataSet allStuState = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStudent_FlowStateList");

				allStuState = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allStuState;
		}

		public DataSet GetTeaState()
		{
			DataSet allTeaState = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Getteacher_flow_stateList");

				allTeaState = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allTeaState;
		}

		public void UpdateTeaState(Int16 stateID,string stateName)
		{
			try
			{
				DBCommandWrapper updateComm = db.GetStoredProcCommandWrapper("Updateteacher_flow_state");
				updateComm.AddInParameter("@teafs_state",DbType.Int16,stateID);
				updateComm.AddInParameter("@teafs_name",DbType.String,stateName);

				db.ExecuteNonQuery(updateComm);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void UpdateStuState(Int16 stateID,string stateName)
		{
			try
			{
				DBCommandWrapper updateComm = db.GetStoredProcCommandWrapper("UpdateStudent_FlowState");
				updateComm.AddInParameter("@state_flowState",DbType.Int16,stateID);
				updateComm.AddInParameter("@state_flowStateName",DbType.String,stateName);

				db.ExecuteNonQuery(updateComm);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void ClearFlowState(int type)
		{
			try
			{
				DBCommandWrapper updateComm = db.GetStoredProcCommandWrapper("ClearFlowState");
				updateComm.AddInParameter("@type",DbType.Int16,type);
				db.ExecuteNonQuery(updateComm);
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		#region IDisposable ��Ա

		public void Dispose()
		{
			// TODO:  ��� CardInfoDA.Dispose ʵ��
			if(db != null)
			{
				db = null;
			}

			GC.SuppressFinalize(true);
		}

		#endregion
	}
}
