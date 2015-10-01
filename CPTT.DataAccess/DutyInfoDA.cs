using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CPTT.SystemFramework;

namespace CPTT.DataAccess
{
	/// <summary>
	/// DutyInfoDA 的摘要说明。
	/// </summary>
	public class DutyInfoDA : IDisposable
	{
		private Database db;

		public DutyInfoDA()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetDutyInfoList()
		{
			DataSet dutyInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Getteacher_dutyList");

				dutyInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dutyInfoList;
		}

		public DataSet GetAllTeaDutyInfo()
		{
			DataSet allTeaDutyInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetAllTeaDutyInfo");

				allTeaDutyInfo = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allTeaDutyInfo;
		}

		public DataSet GetTeaDutyDetails(string startTime,string endTime,string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet teaDutyDetails = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("TeacherDutyDetails");
				dbCom.AddInParameter("@startTime",DbType.String,startTime);
				dbCom.AddInParameter("@endTime",DbType.String,endTime);
				dbCom.AddInParameter("@getDept",DbType.String,getDept);
				dbCom.AddInParameter("@getDuty",DbType.String,getDuty);
				dbCom.AddInParameter("@getName",DbType.String,getName);
				dbCom.AddInParameter("@getNumber",DbType.String,getNumber);

				teaDutyDetails = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return teaDutyDetails;
		}

		public DataSet GetTeaDutyNormal(string getDept,string getDuty,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate,int state)
		{
			DataSet teaDutyNormal = null;
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("TeacherDutyNormal");
				dbCom.AddInParameter("@getTeaDept",DbType.String,getDept);
				dbCom.AddInParameter("@getTeaDuty",DbType.String,getDuty);
				dbCom.AddInParameter("@getTeaName",DbType.String,getName);
				dbCom.AddInParameter("@getTeaNumber",DbType.String,getNumber);
				dbCom.AddInParameter("@getBegDate",DbType.String,getBegDate.ToString("yyyy-MM-dd HH:mm:ss"));
				dbCom.AddInParameter("@getEndDate",DbType.String,getEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
				dbCom.AddInParameter("@state", DbType.Int32, state);
				teaDutyNormal = db.ExecuteDataSet(dbCom);

				DataColumn orderColumn = new DataColumn("T_OrderNumber");
				orderColumn.DataType = System.Type.GetType("System.Int32");
				teaDutyNormal.Tables[0].Columns.Add(orderColumn);
				for ( int i=0; i<teaDutyNormal.Tables[0].Rows.Count; i++ )
					teaDutyNormal.Tables[0].Rows[i]["T_OrderNumber"] = i+1;
			}
			catch(Exception e)
			{
				throw e;
			}

			return teaDutyNormal;
		}

		public DataSet GetTeaOutDetails(DateTime startTime,DateTime endTime,string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet teaOutDetails = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("TeacherOutDetails");
				dbCom.AddInParameter("@startTime",DbType.DateTime,startTime);
				dbCom.AddInParameter("@endTime",DbType.DateTime,endTime);
				dbCom.AddInParameter("@getDept",DbType.String,getDept);
				dbCom.AddInParameter("@getDuty",DbType.String,getDuty);
				dbCom.AddInParameter("@getName",DbType.String,getName);
				dbCom.AddInParameter("@getNumber",DbType.String,getNumber);

				teaOutDetails = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return teaOutDetails;
		}

		public void UpdateTeaOndutyRemarks(int teaOndutyID,string remarks)
		{
			try
			{
				DBCommandWrapper updateComm = db.GetStoredProcCommandWrapper("UpdateTeaOnDutyRemarks");
				updateComm.AddInParameter("@Teaondutyanaly_Number",DbType.Int32,teaOndutyID);
				updateComm.AddInParameter("@Teaondutyanaly_Remark",DbType.String,remarks);

				db.ExecuteNonQuery(updateComm);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int UpdateDutyInfo(DataSet dutyInfoList)
		{
			int rowsEffected = 0;

			try
			{
				DBCommandWrapper insertComm = db.GetStoredProcCommandWrapper("Insertteacher_duty");
				insertComm.AddInParameter("@Teaduty_Begtime",DbType.String,"Teaduty_Begtime",DataRowVersion.Current);
				insertComm.AddInParameter("@Teaduty_Endtime",DbType.String,"Teaduty_Endtime",DataRowVersion.Current);
				insertComm.AddInParameter("@Teaduty_Name ",DbType.String,"Teaduty_Name",DataRowVersion.Current);
				insertComm.AddInParameter("@Teaduty_Remark",DbType.String,"Teaduty_Remark",DataRowVersion.Current);
				insertComm.AddOutParameter("@Teaduty_Dutynumber",DbType.Int32,4);

				DBCommandWrapper updateComm = db.GetStoredProcCommandWrapper("Updateteacher_duty");
				updateComm.AddInParameter("@Teaduty_Dutynumber",DbType.Int32,"Teaduty_Dutynumber",DataRowVersion.Current);
				updateComm.AddInParameter("@Teaduty_Begtime",DbType.String,"Teaduty_Begtime",DataRowVersion.Current);
				updateComm.AddInParameter("@Teaduty_Endtime",DbType.String,"Teaduty_Endtime",DataRowVersion.Current);
				updateComm.AddInParameter("@Teaduty_Name ",DbType.String,"Teaduty_Name",DataRowVersion.Current);
				updateComm.AddInParameter("@Teaduty_Remark",DbType.String,"Teaduty_Remark",DataRowVersion.Current);

				DBCommandWrapper deleteComm = db.GetStoredProcCommandWrapper("Deleteteacher_duty");
				deleteComm.AddInParameter("@Teaduty_Dutynumber",DbType.Int32,"Teaduty_Dutynumber",DataRowVersion.Proposed);

				rowsEffected = db.UpdateDataSet(dutyInfoList,dutyInfoList.Tables[0].TableName,
					insertComm,updateComm,deleteComm,UpdateBehavior.Transactional);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rowsEffected;
		}

		public int UpdateTeaDutyDetail(string tID,string sundayDuty,
			string mondayDuty,string tuesdayDuty,string wednesdayDuty,
			string thursdayDuty,string fridayDuty,string saturdayDuty)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("Updateteacher_onduty");

				dbCom.AddInParameter("@Teaonduty_Teaid",DbType.String,tID);
				dbCom.AddInParameter("@Teaonduty_Sunday",DbType.String,sundayDuty);
				dbCom.AddInParameter("@Teaonduty_Monday",DbType.String,mondayDuty);
				dbCom.AddInParameter("@Teaonduty_Tuesday",DbType.String,tuesdayDuty);
				dbCom.AddInParameter("@Teaonduty_Wednesday",DbType.String,wednesdayDuty);
				dbCom.AddInParameter("@Teaonduty_Thursday",DbType.String,thursdayDuty);
				dbCom.AddInParameter("@Teaonduty_Friday",DbType.String,fridayDuty);
				dbCom.AddInParameter("@Teaonduty_Saturday",DbType.String,saturdayDuty);
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

		public int[] TeaDutyReport(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber)
		{
			int[] reportResult = new int[4];

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DutyReports");

				dbCom.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
				dbCom.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
				dbCom.AddInParameter("@getDept",DbType.String,getDept);
				dbCom.AddInParameter("@getDuty",DbType.String,getDuty);
				dbCom.AddInParameter("@getName",DbType.String,getName);
				dbCom.AddInParameter("@getNumber",DbType.String,getNumber);
				dbCom.AddOutParameter("@lateCount",DbType.Int32,4);
				dbCom.AddOutParameter("@earlyCount",DbType.Int32,4);
				dbCom.AddOutParameter("@totalCount",DbType.Int32,4);
				dbCom.AddOutParameter("@outCount",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				if(dbCom.GetParameterValue("@lateCount")!=DBNull.Value)
				{
					reportResult[0] = Convert.ToInt32(dbCom.GetParameterValue("@lateCount"));
				}
				else
				{
					reportResult[0] = 0;
				}

				if(dbCom.GetParameterValue("@earlyCount")!=DBNull.Value)
				{
					reportResult[1] = Convert.ToInt32(dbCom.GetParameterValue("@earlyCount"));
				}
				else
				{
					reportResult[1] = 0;
				}

				if(dbCom.GetParameterValue("@totalCount")!=DBNull.Value)
				{
					reportResult[2] = Convert.ToInt32(dbCom.GetParameterValue("@totalCount"));
				}
				else
				{
					reportResult[2] = 0;
				}

				if(dbCom.GetParameterValue("@outCount")!=DBNull.Value)
				{
					reportResult[3] = Convert.ToInt32(dbCom.GetParameterValue("@outCount"));
				}
				else
				{
					reportResult[3] = 0;
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return reportResult;
		}

		public int UpdateDutyInfo(DateTime getHisDutyDate,bool isToLoadCurDuty)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateDutyInfo");
				dbCommandWrapper.AddInParameter("@getDutyWeek",DbType.DateTime,getHisDutyDate);
				dbCommandWrapper.AddInParameter("@getCurDutyWeek",DbType.DateTime,DateTime.Now);
				dbCommandWrapper.AddInParameter("@isToLoadCurDuty",DbType.Boolean,isToLoadCurDuty);
				dbCommandWrapper.AddOutParameter("@getErrorMsg",DbType.Int32,4);
				db.ExecuteNonQuery(dbCommandWrapper);
				return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getErrorMsg"));
			}
			catch(Exception e)
			{
				throw e;
			}
		}

		public int CalcTeaDutyInfo(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber,bool isThisWeek)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper;

				if ( !isThisWeek )
					dbCommandWrapper = db.GetStoredProcCommandWrapper("CalcTeaDuty");
				else
					dbCommandWrapper = db.GetStoredProcCommandWrapper("GetDutyInfoThisWeek");

				dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
				dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
				dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
				dbCommandWrapper.AddInParameter("@getDuty",DbType.String,getDuty);
				dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
				dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
				dbCommandWrapper.AddOutParameter("@getAttendTimes",DbType.Int32,4);
				db.ExecuteNonQuery(dbCommandWrapper);
				return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAttendTimes"));
			}
			catch(Exception e)
			{
				throw e;
			}
		}

		public int SaveCurDuty()
		{
			int rowsAffected = 0;
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("SaveCurDuty");
				dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,DateTime.Now);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
				db.ExecuteNonQuery(dbCommandWrapper);
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception e)
			{
				throw e;
			}

			return rowsAffected;
		}

		public DataSet GetTeaListForDutySummary(string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet getTeaListForDutySummary = null;
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetTeaListForDutySummary");
				dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
				dbCommandWrapper.AddInParameter("@getDuty",DbType.String,getDuty);
				dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
				dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
				getTeaListForDutySummary = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception e)
			{
				throw e;
			}

			return getTeaListForDutySummary;
		}

		public DataTable GetTeacherStatByDuty(DateTime startDate, DateTime endDate)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetTeacherStatByDuty");
				dbCommandWrapper.AddInParameter("@startDate",DbType.String,startDate.ToString("yyyy-MM-dd 00:00:00"));
				dbCommandWrapper.AddInParameter("@endDate",DbType.String, endDate.ToString("yyyy-MM-dd 23:59:59"));
				return db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataTable GetTeacherStatSingle(DateTime startDate, DateTime endDate)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetTeacherStatSingle");
				dbCommandWrapper.AddInParameter("@startDate",DbType.String,startDate.ToString("yyyy-MM-dd 00:00:00"));
				dbCommandWrapper.AddInParameter("@endDate",DbType.String, endDate.ToString("yyyy-MM-dd 23:59:59"));
				return db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		#region IDisposable 成员

		public void Dispose()
		{
			// TODO:  添加 CardInfoDA.Dispose 实现
			if(db != null)
			{
				db = null;
			}

			GC.SuppressFinalize(true);
		}

		#endregion
	}
}
