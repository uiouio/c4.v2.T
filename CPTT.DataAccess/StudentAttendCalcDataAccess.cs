using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// StudentAttendCalcDataAccess 的摘要说明。
	/// </summary>
	public class StudentAttendCalcDataAccess :IDisposable
	{
		private Database dbAttendCalc = DatabaseFactory.CreateDatabase();
		private string doGetStatusListCommand = string.Empty;
		private string doStuAttendCalcForClassCommand = string.Empty;
		private string doStuAttendCalcForSoloCommand = string.Empty;
		private string doStuBackCalcCommand = string.Empty;
		private DBCommandWrapper dbCommandWrapper;
		private int getStateAmount;
		private int getStuAmount;
		private int getAllStateAmount;
		private int getHasGone;
		private int getHasnotGone;

		public StudentAttendCalcDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int StateAmount
		{
			get{ return this.getStateAmount; }
			set{ this.getStateAmount = value;}
		}

		public int StuAmount
		{
			get{ return this.getStuAmount;}
			set{ this.getStuAmount = value;}
		}

		public int AllStateAmount
		{
			get{ return this.getAllStateAmount; }
			set{ this.getAllStateAmount = value; }
		}

		public int HasGone
		{
			get { return this.getHasGone; }
			set { this.getHasGone = value; }
		}

		public int HasnotGone
		{
			get { return this.getHasnotGone; }
			set { this.getHasnotGone = value; }
		}


		public DataSet DoGetStatusList()
		{
			doGetStatusListCommand = "GetStatusList";
			dbCommandWrapper = dbAttendCalc.GetStoredProcCommandWrapper(doGetStatusListCommand);
			return dbAttendCalc.ExecuteDataSet(dbCommandWrapper);
		}

		public void DoAttendCalcForClass(string getGrade,string getClass,string getBegTime,
			string getEndTime,string getState)
		{
			doStuAttendCalcForClassCommand = "Student_AttendCalcForClass";
			dbCommandWrapper = dbAttendCalc.GetStoredProcCommandWrapper(doStuAttendCalcForClassCommand);
			dbCommandWrapper.AddInParameter("@setGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@setClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@setBegTime",DbType.String,getBegTime);
			dbCommandWrapper.AddInParameter("@setEndTime",DbType.String,getEndTime);
			dbCommandWrapper.AddInParameter("@setState",DbType.String,getState);
			dbCommandWrapper.AddOutParameter("@getStateAmount",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getAllStateAmount",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getStuAmount",DbType.Int32,4);
			dbAttendCalc.ExecuteDataSet(dbCommandWrapper);
			StateAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStateAmount"));
			StuAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStuAmount"));
			AllStateAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAllStateAmount"));
		}

		public void DoAttendCalcForSolo(string getName,string getNumber,string getBegTime,
			string getEndTime,string getState)
		{
			doStuAttendCalcForSoloCommand = "Student_AttendCalcForSolo";
			dbCommandWrapper = dbAttendCalc.GetStoredProcCommandWrapper(doStuAttendCalcForSoloCommand);
			dbCommandWrapper.AddInParameter("@setStuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@setStuNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@setBegTime",DbType.String,getBegTime);
			dbCommandWrapper.AddInParameter("@setEndTime",DbType.String,getEndTime);
			dbCommandWrapper.AddInParameter("@setState",DbType.String,getState);
			dbCommandWrapper.AddOutParameter("@getStateAmount",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getAllStateAmount",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getStuAmount", DbType.Int32, 4);
			dbAttendCalc.ExecuteDataSet(dbCommandWrapper);
			StateAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStateAmount"));
			AllStateAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAllStateAmount"));
			StuAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getStuAmount"));
		}

		public void DoBackCalc(string getGrade,string getClass,string getName,string getNumber,string getBegTime,
			string getEndTime)
		{
			doStuBackCalcCommand = "Student_BackCalc";
			dbCommandWrapper = dbAttendCalc.GetStoredProcCommandWrapper(doStuBackCalcCommand);
			dbCommandWrapper.AddInParameter("@setGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@setClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@setName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@setNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@setBegTime",DbType.String,getBegTime);
			dbCommandWrapper.AddInParameter("@setEndTime",DbType.String,getEndTime);
			dbCommandWrapper.AddOutParameter("@getHasGone",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getHasnotGone",DbType.Int32,4);
			dbCommandWrapper.AddOutParameter("@getAllStateAmount",DbType.Int32,4);
			dbAttendCalc.ExecuteDataSet(dbCommandWrapper);
			HasGone = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getHasGone"));
			HasnotGone = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getHasnotGone"));
			AllStateAmount = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAllStateAmount"));
		}
     

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return ;
			else
			{
				if ( dbAttendCalc != null )
					dbAttendCalc = null;
			}
		}
	}
}
