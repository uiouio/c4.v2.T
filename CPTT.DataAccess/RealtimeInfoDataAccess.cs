using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// RealtimeInfoDataAccess 的摘要说明。
	/// </summary>
	public class RealtimeInfoDataAccess :IDisposable
	{
		private Database dbRealtime = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getRealtimeInfoCommand = string.Empty;
		private string getStuAmountCommand = string.Empty;
		private string getClassListCommand = string.Empty;
		private string getRealtimeMorningInfo_GraphicCommand = string.Empty;
		private string getRealtimeBackInfo_GraphicCommand = string.Empty;
		public RealtimeInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet setRealtime(DateTime getDate,string getGrade,string getClass,int getState,int needSum)
		{
			return FillRealtime(getDate,getGrade,getClass,getState,needSum);
		}

		public DataSet setStuAmount(string getMachineAddr,DateTime getEndDate)
		{
			return FillStuAmount(getMachineAddr,getEndDate);
		}

		public DataSet setClassList(string getClassName,string getClassNumber,string getGradeNumber)
		{
			return FillClassList(getClassName,getClassNumber,getGradeNumber);
		}

		public void GetRealtimeMorningInfo_Graphic(string getGrade,string getClass,DateTime getDate,ref int getHealth,
			ref int getWatch,ref int getSick,ref int getAbsence,ref int getStuNumbers)
		{
			getRealtimeMorningInfo_GraphicCommand = "GetRealtimeMorningStat_Graphic";
			dbCommandWrapper = dbRealtime.GetStoredProcCommandWrapper(getRealtimeMorningInfo_GraphicCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@getHealth",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getWatch",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getSick",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getAbsence",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getStuNumbers",DbType.Int32,4);
			dbRealtime.ExecuteNonQuery(dbCommandWrapper);

			getHealth = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getHealth"));
			getWatch = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getWatch"));
			getSick = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getSick"));
			getAbsence = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAbsence"));
			getStuNumbers = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStuNumbers"));
		}

		public void GetRealtimeBackInfo_Graphic(string getGrade,string getClass,DateTime getDate,ref int getHasGone,ref int getHasnotGone,ref int getStuNumbers)
		{
			getRealtimeBackInfo_GraphicCommand = "GetRealtimeBackStat_Graphic";
			dbCommandWrapper = dbRealtime.GetStoredProcCommandWrapper(getRealtimeBackInfo_GraphicCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@getHasGone",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getHasnotGone",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getStuNumbers",DbType.Int32,4);
			dbRealtime.ExecuteNonQuery(dbCommandWrapper);

			getHasGone = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getHasGone"));
			getHasnotGone = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getHasnotGone"));
			getStuNumbers = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStuNumbers"));
		}

		private DataSet FillRealtime(DateTime getDate,string getGrade,string getClass,int getState,int needSum)
		{
			getRealtimeInfoCommand = "GetRealTimeInfo";
			dbCommandWrapper = dbRealtime.GetStoredProcCommandWrapper(getRealtimeInfoCommand);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate.Date.ToString("yyyy-MM-dd"));
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getState",DbType.Int32,getState);
			dbCommandWrapper.AddInParameter("@needSum",DbType.Int32,needSum);
			return dbRealtime.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuAmount(string getMachineAddr,DateTime getEndDate)
		{
			getStuAmountCommand = "GetStuAmount";
			dbCommandWrapper = dbRealtime.GetStoredProcCommandWrapper(getStuAmountCommand);
			dbCommandWrapper.AddInParameter("@machineAddr",DbType.String,getMachineAddr);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			return dbRealtime.ExecuteDataSet(dbCommandWrapper);
		}
		
		private DataSet FillClassList(string getClassName,string getClassNumber,string getGradeNumber)
		{
			getClassListCommand = "GetClassList";
			dbCommandWrapper = dbRealtime.GetStoredProcCommandWrapper(getClassListCommand);
			dbCommandWrapper.AddInParameter("@ClassName",DbType.String,getClassName);
			dbCommandWrapper.AddInParameter("@ClassNumber",DbType.String,getClassNumber);
			dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,getGradeNumber);
			return dbRealtime.ExecuteDataSet(dbCommandWrapper);

		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
			{
				return;
			}
			else
			{
				if ( dbRealtime != null )
				{
					dbRealtime = null;
				}
			}
		}

	}

	

}
