using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
namespace CPTT.DataAccess
{
	/// <summary>
	/// RealtimeInfo_TeacherDataAccess 的摘要说明。
	/// </summary>
	public class RealtimeInfo_TeacherDataAccess :IDisposable
	{
		private Database dbRealtimeInfo = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getTeaNumbersCommand;
		private string getDutyIDCommand;
		private string getTeaWorkingNumbersCommand;
		private string getTeaDeptInfoCommand;
		private string getTeaLeaveNumbersCommand;
		public RealtimeInfo_TeacherDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		public int GetTeaNumbers(string getWeekDay,string getDutyID,string getDept)
		{
			return FillTeaNumbers(getWeekDay,getDutyID,getDept);
		}

		public DataSet GetDutyID(string getTime)
		{
			return FillDutyID(getTime);
		}

		public void GetTeaWorkingNumbers(string getDutyID,ref int getTeaWorkingOnTime,ref int getTeaWorkingnotOnTime,string getDept,DateTime getDate)
		{
			FillTeaWorkingNumbers(getDutyID,ref getTeaWorkingOnTime,ref getTeaWorkingnotOnTime,getDept,getDate);
		}

		public DataSet GetTeaDeptInfo(string getDept)
		{
			return FillGetTeaDeptInfo(getDept);
		}

		public void GetTeaLeaveNumbers(string getDutyID,ref int getTeaLeaveOnTime,ref int getTeaLeaveNotOnTime,string getDept,DateTime getDate)
		{
			FillTeaLeaveNumbers(getDutyID,ref getTeaLeaveOnTime,ref getTeaLeaveNotOnTime,getDept,getDate);
		}

		public void GetTeacherRealTimeInfoWithNoDuty(string dept,string getWeekDay, ref int total, ref int attend, ref int leave)
		{
			FillTeacherRealTimeInfoWithNoDuty(dept,getWeekDay, ref total, ref attend, ref leave);
		}

		private void FillTeacherRealTimeInfoWithNoDuty(string dept,string getWeekDay,  ref int total, ref int attend, ref int leave)
		{
			string getRealTimeInfoWithNoDuty = "GetTeacher_RealTimeInfo_WithNoDuty";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getRealTimeInfoWithNoDuty);
			dbCommandWrapper.AddInParameter("@getDayOfWeek", DbType.String, getWeekDay);
			dbCommandWrapper.AddInParameter("@getDept", DbType.String, dept);
			DataSet dsInfo = dbRealtimeInfo.ExecuteDataSet(dbCommandWrapper);
			total = Convert.ToInt32(dsInfo.Tables[0].Rows[0][0]);
			attend = Convert.ToInt32(dsInfo.Tables[1].Rows[0][0]);
			leave =  Convert.ToInt32(dsInfo.Tables[2].Rows[0][0]);
		}

		private int FillTeaNumbers(string getWeekDay,string getDutyID,string getDept)
		{
			getTeaNumbersCommand = "GetTeaNumberInDuty";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getTeaNumbersCommand);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getWeekDay",DbType.String,getWeekDay);
			dbCommandWrapper.AddInParameter("@getDutyID",DbType.String,getDutyID);
			dbCommandWrapper.AddOutParameter("@getTeaNumbers",DbType.Int32,4);
			dbRealtimeInfo.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTeaNumbers"));
		}

		private DataSet FillDutyID(string getTime)
		{
			getDutyIDCommand = "GetDutyID_InTime";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getDutyIDCommand);
			dbCommandWrapper.AddInParameter("@getTime",DbType.String,getTime);
			return dbRealtimeInfo.ExecuteDataSet(dbCommandWrapper);
		}
	
		private void FillTeaWorkingNumbers(string getDutyID,ref int getTeaWorkingOnTime,ref int getTeaWorkingnotOnTime,string getDept,DateTime getDate)
		{
			getTeaWorkingNumbersCommand = "GetTeaWorkingNumbers";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getTeaWorkingNumbersCommand);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getDutyID",DbType.String,getDutyID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@getTeaWorkingOnTime",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getTeaWorkingnotOnTime",DbType.Int32,4);
			dbRealtimeInfo.ExecuteNonQuery(dbCommandWrapper);

			getTeaWorkingOnTime += Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTeaWorkingOnTime"));
			getTeaWorkingnotOnTime += Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTeaWorkingnotOnTime"));
		}

		private DataSet FillGetTeaDeptInfo(string getDept)
		{
			getTeaDeptInfoCommand = "GetTeaDeptInfo";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getTeaDeptInfoCommand);	
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			return dbRealtimeInfo.ExecuteDataSet(dbCommandWrapper);
		}

		private void FillTeaLeaveNumbers(string getDutyID,ref int getTeaLeaveOnTime,ref int getTeaLeaveNotOnTime,string getDept,DateTime getDate)
		{
			getTeaLeaveNumbersCommand = "GetTeaLeaveNumbers";
			dbCommandWrapper = dbRealtimeInfo.GetStoredProcCommandWrapper(getTeaLeaveNumbersCommand);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getDutyID",DbType.String,getDutyID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@getTeaLeaveOnTime",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getTeaLeavenotOnTime",DbType.Int32,4);
			dbRealtimeInfo.ExecuteNonQuery(dbCommandWrapper);

			getTeaLeaveOnTime += Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTeaLeaveOnTime"));
			getTeaLeaveNotOnTime += Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTeaLeavenotOnTime"));
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return ;
			else
			{
				if ( dbRealtimeInfo != null )
					dbRealtimeInfo = null;
			}
		}
	}
}
