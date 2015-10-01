//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;
using System.Data;

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// TeacherBaseDataAccess ��ժҪ˵����
	/// </summary>
	public class TeacherBaseDataAccess : IDisposable
	{
	    private Database db = null;
		public TeacherBaseDataAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetTcBaseList()
		{
			DataSet tcBaseList;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetTeach_Base_InfoList");
				
				tcBaseList = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return tcBaseList;
		}

		public DataSet GetTcBaseInfo(string tID)
		{
			DataSet TcBaseInfo;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetTeach_Base_Info");
				dbCommandWrapper.AddInParameter("@T_ID",DbType.Int32,tID);

				TcBaseInfo = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return TcBaseInfo;
		}

		public int InsertTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;
			
			try
			{				
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertTeach_Base_Info");
				dbCommandWrapper.AddInParameter("@T_ID",DbType.String,tcBase.TID);
				dbCommandWrapper.AddInParameter("@T_Number",DbType.String,tcBase.TNumber);
				dbCommandWrapper.AddInParameter("@T_Name",DbType.String,tcBase.TName);
				dbCommandWrapper.AddInParameter("@T_Sex",DbType.String,tcBase.TSex);
				dbCommandWrapper.AddInParameter("@T_Merrige",DbType.String,tcBase.TMerrige);
				dbCommandWrapper.AddInParameter("@T_Addr",DbType.String,tcBase.TAddr);
				dbCommandWrapper.AddInParameter("@T_Career",DbType.String,tcBase.TCareer);
				dbCommandWrapper.AddInParameter("@T_Home_Tel",DbType.String,tcBase.THomeTel);
				dbCommandWrapper.AddInParameter("@T_Phone",DbType.String,tcBase.TPhone);
				dbCommandWrapper.AddInParameter("@T_Work_Tel",DbType.String,tcBase.TWorkTel);
				dbCommandWrapper.AddInParameter("@T_Depart",DbType.String,tcBase.TDepart);
				dbCommandWrapper.AddInParameter("@T_Duty",DbType.String,tcBase.TDuty);
				dbCommandWrapper.AddInParameter("@T_Technical_Post",DbType.String,tcBase.TTechnicalPost);
				dbCommandWrapper.AddInParameter("@T_Level",DbType.String,tcBase.TLevel);
				dbCommandWrapper.AddInParameter("@T_Work_Time",DbType.String,tcBase.TWorkTime);
				dbCommandWrapper.AddInParameter("@T_Enter_Time",DbType.String,tcBase.TEnterTime);
				dbCommandWrapper.AddInParameter("@T_Image",DbType.Binary,tcBase.ImageData);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rowsAffected;
		}

		public int UpdateTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateTeach_Base_Info");
				dbCommandWrapper.AddInParameter("@T_ID",DbType.String,tcBase.TID);
				dbCommandWrapper.AddInParameter("@T_Number",DbType.String,tcBase.TNumber);
				dbCommandWrapper.AddInParameter("@T_Name",DbType.String,tcBase.TName);
				dbCommandWrapper.AddInParameter("@T_Sex",DbType.String,tcBase.TSex);
				dbCommandWrapper.AddInParameter("@T_Merrige",DbType.String,tcBase.TMerrige);
				dbCommandWrapper.AddInParameter("@T_Addr",DbType.String,tcBase.TAddr);
				dbCommandWrapper.AddInParameter("@T_Career",DbType.String,tcBase.TCareer);
				dbCommandWrapper.AddInParameter("@T_Home_Tel",DbType.String,tcBase.THomeTel);
				dbCommandWrapper.AddInParameter("@T_Phone",DbType.String,tcBase.TPhone);
				dbCommandWrapper.AddInParameter("@T_Work_Tel",DbType.String,tcBase.TWorkTel);
				dbCommandWrapper.AddInParameter("@T_Depart",DbType.String,tcBase.TDepart);
				dbCommandWrapper.AddInParameter("@T_Duty",DbType.String,tcBase.TDuty);
				dbCommandWrapper.AddInParameter("@T_Technical_Post",DbType.String,tcBase.TTechnicalPost);
				dbCommandWrapper.AddInParameter("@T_Level",DbType.String,tcBase.TLevel);
				dbCommandWrapper.AddInParameter("@T_Work_Time",DbType.String,tcBase.TWorkTime);
				dbCommandWrapper.AddInParameter("@T_Enter_Time",DbType.String,tcBase.TEnterTime);
				dbCommandWrapper.AddInParameter("@T_Image",DbType.Binary,tcBase.ImageData);

				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteTcBaseInfo(string tID)
		{
			int rowsAffected = 0;
			
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("DeleteTeach_Base_Info");
				dbCommandWrapper.AddInParameter("@T_ID",DbType.String,tID);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);

				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public DataSet GetTcBaseInfo(string gradeName,string className,string tcName,string tcNumber)
		{
			DataSet tcBaseList;
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("SearchTcBaseInfoByCondition");
				dbCommandWrapper.AddInParameter("@T_Depart",DbType.String,gradeName);
				dbCommandWrapper.AddInParameter("@T_Duty",DbType.String,className);
				dbCommandWrapper.AddInParameter("@T_Name",DbType.String,tcName);
				dbCommandWrapper.AddInParameter("@T_Number",DbType.String,tcNumber);

				tcBaseList = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return tcBaseList;
		}

		public bool HasCard(string tID,string tNumber)
		{
			bool hasCard;
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("HasCard_Teacher");
				dbCommandWrapper.AddInParameter("@tID",DbType.String,tID);
				dbCommandWrapper.AddInParameter("@tNumber",DbType.String,tNumber);
				dbCommandWrapper.AddOutParameter("@hasCard",DbType.Boolean,1);
				db.ExecuteNonQuery(dbCommandWrapper);
				hasCard = Convert.ToBoolean(dbCommandWrapper.GetParameterValue("@hasCard"));
			}
			catch(Exception e)
			{
				throw e;
			}

			return hasCard;
		}

		#region IDisposable ��Ա

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
