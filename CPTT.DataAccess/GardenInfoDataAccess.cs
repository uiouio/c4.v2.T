using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// 幼儿园信息数据访问层
	/// </summary>
	public class GardenInfoDataAccess : IDisposable
	{
		private Database db = null;

		public GardenInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		/// <summary>
		/// 插入幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要插入的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int InsertGardenInfo(GardenInfo gardenInfo)
		{
			int rowEffected = 0;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("InsertGarden_Info");
				dbComWrapper.AddInParameter("@info_gardenID",DbType.String,gardenInfo.GardenID);
				dbComWrapper.AddInParameter("@info_gardenName",DbType.String,gardenInfo.GardenName);
				dbComWrapper.AddInParameter("@info_gardenRegCode",DbType.String,gardenInfo.GardenRegCode);
				dbComWrapper.AddInParameter("@info_gardenAddr",DbType.String,gardenInfo.GardenAddr);
				dbComWrapper.AddInParameter("@info_gardenContact",DbType.String,gardenInfo.GardenContact);
				dbComWrapper.AddInParameter("@info_gardenFeature",DbType.String,gardenInfo.GardenFeature);
				dbComWrapper.AddInParameter("@info_gardenGraphLocation",DbType.Binary,gardenInfo.GardenImage);
				dbComWrapper.AddOutParameter("@rowEffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbComWrapper);

				rowEffected = Convert.ToInt32(dbComWrapper.GetParameterValue("@rowEffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowEffected;
		}

		/// <summary>
		/// 更新幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要更改的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int UpdateGardenInfo(GardenInfo gardenInfo)
		{
			int rowEffected = 0;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("UpdateGarden_Info");
				dbComWrapper.AddInParameter("@info_gardenID",DbType.String,gardenInfo.GardenID);
				dbComWrapper.AddInParameter("@info_gardenName",DbType.String,gardenInfo.GardenName);
				dbComWrapper.AddInParameter("@info_gardenRegCode",DbType.String,gardenInfo.GardenRegCode);
				dbComWrapper.AddInParameter("@info_gardenAddr",DbType.String,gardenInfo.GardenAddr);
				dbComWrapper.AddInParameter("@info_gardenContact",DbType.String,gardenInfo.GardenContact);
				dbComWrapper.AddInParameter("@info_gardenFeature",DbType.String,gardenInfo.GardenFeature);
				dbComWrapper.AddInParameter("@info_gardenGraphLocation",DbType.Binary,gardenInfo.GardenImage);
				dbComWrapper.AddOutParameter("@rowEffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbComWrapper);

				rowEffected = Convert.ToInt32(dbComWrapper.GetParameterValue("@rowEffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowEffected;
		}

		public DataSet GetMachineInfo()
		{
			DataSet dsMachineInfo = null;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("gar_get_machine_info");
				dsMachineInfo = db.ExecuteDataSet(dbComWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dsMachineInfo;
		}

		/// <summary>
		/// 删除幼儿园信息
		/// </summary>
		/// <param name="gardenID">要删除的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int DeleteGardenInfo(string gardenID)
		{
			return 0;
		}

		/// <summary>
		/// 检索幼儿园信息
		/// </summary>
		/// <returns>返回GardenInfo所有信息的DataSet</returns>
		public DataSet GetGardenInfo()
		{
			DataSet gardenInfo;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("GetGarden_InfoList");

				gardenInfo = db.ExecuteDataSet(dbComWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return gardenInfo;
		}

		public int AddNewMachine(int machineAddr)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("gar_Add_New_Machine");
				dbComWrapper.AddInParameter("@machine_addr",DbType.Int32,machineAddr);
				dbComWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
				db.ExecuteNonQuery(dbComWrapper);
				rowsAffected = Convert.ToInt32(dbComWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteMachine(int machineAddr)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbComWrapper = db.GetStoredProcCommandWrapper("gar_Delete_Machine");
				dbComWrapper.AddInParameter("@machine_addr",DbType.Int32,machineAddr);
				dbComWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
				db.ExecuteNonQuery(dbComWrapper);
				rowsAffected = Convert.ToInt32(dbComWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); 
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 

			if (db != null)
			{
				db = null;
			}
		}

		#endregion
	}
}
