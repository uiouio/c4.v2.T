using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
namespace CPTT.DataAccess
{
	/// <summary>
	/// StuVisitInfoDataAccess 的摘要说明。
	/// </summary>
	public class StuVisitInfoDataAccess :IDisposable
	{
		private Database dbVisit = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string get2DaysAbsCommand = string.Empty;
		private string getAbsentDaysInMonthCommand = string.Empty;
		private string getAbsenceDetailCommand = string.Empty;
		private string doAbsenceInfoInsertCommand = string.Empty;
		private string doAbsenceInfoDeleteCommand = string.Empty;
		private string doAbsenceInfoUpdateCommand = string.Empty;
		private int getAbsSum;

		public StuVisitInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int GetAbsSum
		{
			get { return this.getAbsSum; }
			set { this.getAbsSum = value; }
		}

		public DataSet Set2DaysAbs(string getGrade,string getClass,DateTime getDate)
		{
			return Fill2DaysAbs(getGrade,getClass,getDate);
		}

		public DataSet SetAbsentDaysInMonth(int getNumber,DateTime getDate)
		{
			return FillAbsentDaysInMonth(getNumber,getDate);
		}

		public DataSet SetAbsenceDetail(string getGrade,string getClass,string getName,string getNumber,
			DateTime getBegDate,DateTime getEndDate)
		{
			return FillAbsenceDetail(getGrade,getClass,getName,getNumber,getBegDate,getEndDate);
		}

		private DataSet Fill2DaysAbs(string getGrade,string getClass,DateTime getDate)
		{
			get2DaysAbsCommand = "Get2DaysAbsence";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(get2DaysAbsCommand);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			return dbVisit.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillAbsentDaysInMonth(int getNumber,DateTime getDate)
		{
			getAbsentDaysInMonthCommand = "GetAbsentDaysInMonth";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(getAbsentDaysInMonthCommand);
			dbCommandWrapper.AddInParameter("@getStuNumber",DbType.Int16,getNumber);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("getAbsSum",DbType.Int32,4);
			DataSet dsAbsentDaysInMonth = dbVisit.ExecuteDataSet(dbCommandWrapper);
			GetAbsSum = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAbsSum"));
			return dsAbsentDaysInMonth;
		}	

		private DataSet FillAbsenceDetail(string getGrade,string getClass,string getName,string getNumber,
			DateTime getBegDate,DateTime getEndDate)
		{
			getAbsenceDetailCommand = "GetAbsenceDetail";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(getAbsenceDetailCommand);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			DataSet dsAbsenceDetail = dbVisit.ExecuteDataSet(dbCommandWrapper);
			DataColumn orderNumberColumn = new DataColumn("info_stuOrderNumber");
			orderNumberColumn.DataType = System.Type.GetType("System.Int32");
			dsAbsenceDetail.Tables[0].Columns.Add(orderNumberColumn);
			for(int i=0;i<dsAbsenceDetail.Tables[0].Rows.Count;i++)
				dsAbsenceDetail.Tables[0].Rows[i][8] = i+1;
			return dsAbsenceDetail;
		}

		public int DoAbsenceInfoInsert(StuVisit stuVisit)
		{
			doAbsenceInfoInsertCommand = "InsertAbsenceInfo";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(doAbsenceInfoInsertCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.Int16,stuVisit.StuNumber);
			dbCommandWrapper.AddInParameter("@absReason",DbType.String,stuVisit.AbsReason);
			dbCommandWrapper.AddInParameter("@visitMode",DbType.String,stuVisit.VisitMode);
			dbCommandWrapper.AddInParameter("@visitDate",DbType.DateTime,stuVisit.VisitDate);
			dbCommandWrapper.AddInParameter("@visitTeaSign",DbType.String,stuVisit.VisitTeaSign);
			dbCommandWrapper.AddInParameter("@absRemark",DbType.String,stuVisit.AbsRemark);
			dbCommandWrapper.AddOutParameter("@rtnState",DbType.Int16,1);
			dbVisit.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt16(dbCommandWrapper.GetParameterValue("@rtnState"));
		}

		public void DoAbsenceInfoDelete(StuVisit stuVisit)
		{
			doAbsenceInfoDeleteCommand = "DeleteAbsenceInfo";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(doAbsenceInfoDeleteCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.Int16,stuVisit.StuNumber);
			dbCommandWrapper.AddInParameter("@absReason",DbType.String,stuVisit.GetAbsReason);
			dbCommandWrapper.AddInParameter("@visitMode",DbType.String,stuVisit.GetVisitMode);
			dbCommandWrapper.AddInParameter("@visitDate",DbType.DateTime,stuVisit.GetVisitDate);
//			dbCommandWrapper.AddInParameter("@visitTeaSign",DbType.String,stuVisit.GetVisitTeaSign);
//			dbCommandWrapper.AddInParameter("@absRemark",DbType.String,stuVisit.GetAbsRemark);
			dbVisit.ExecuteNonQuery(dbCommandWrapper);
		}

		public void DoAbsenceInfoUpdate(StuVisit stuVisit)
		{
			doAbsenceInfoUpdateCommand = "UpdateAbsenceInfo";
			dbCommandWrapper = dbVisit.GetStoredProcCommandWrapper(doAbsenceInfoUpdateCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.Int16,stuVisit.StuNumber);
			dbCommandWrapper.AddInParameter("@absReason",DbType.String,stuVisit.AbsReason);
			dbCommandWrapper.AddInParameter("@visitMode",DbType.String,stuVisit.VisitMode);
			dbCommandWrapper.AddInParameter("@visitDate",DbType.DateTime,stuVisit.VisitDate);
			dbCommandWrapper.AddInParameter("@visitTeaSign",DbType.String,stuVisit.VisitTeaSign);
			dbCommandWrapper.AddInParameter("@absRemark",DbType.String,stuVisit.AbsRemark);
			dbCommandWrapper.AddInParameter("@getAbsReason",DbType.String,stuVisit.GetAbsReason);
			dbCommandWrapper.AddInParameter("@getVisitMode",DbType.String,stuVisit.GetVisitMode);
			dbCommandWrapper.AddInParameter("@getVisitDate",DbType.DateTime,stuVisit.GetVisitDate);
			dbCommandWrapper.AddInParameter("@getVisitTeaSign",DbType.String,stuVisit.GetVisitTeaSign);
//			dbCommandWrapper.AddInParameter("@getAbsRemark",DbType.String,stuVisit.GetAbsRemark);
			dbVisit.ExecuteNonQuery(dbCommandWrapper);
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
				if ( dbVisit != null )
					dbVisit = null;
			}
		}
	}
}
