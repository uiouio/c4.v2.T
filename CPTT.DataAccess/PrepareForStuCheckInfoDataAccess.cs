using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
namespace CPTT.DataAccess
{
	/// <summary>
	/// PrepareForStuCheckInfoDataAccess 的摘要说明。
	/// </summary>
	public class PrepareForStuCheckInfoDataAccess:IDisposable
	{
		private Database dbPrepareForCheck = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string fillAbsentStudentCommand;
		private string checkAbsDoneYesterdayCommand;
		private string checkTeaDutyCommand;
		private string saveAlternateCommand;

		public PrepareForStuCheckInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void DoPrepareForCheck()
		{
			CheckTeaDuty();
			SaveTeaAlternate();
			FillAbsentStudent();
            RunDefault();
            FillContiAbsentStudent();
			//CheckAbsDoneYesterday();	
		}

		private void FillAbsentStudent()
		{
			fillAbsentStudentCommand = "FillAbsentStudent";
			dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper(fillAbsentStudentCommand);
			dbCommandWrapper.CommandTimeout = 180;
			dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
		}

		private void CheckAbsDoneYesterday()
		{
			checkAbsDoneYesterdayCommand = "CheckAbsDoneYesterday";
			dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper(checkAbsDoneYesterdayCommand);
			dbCommandWrapper.CommandTimeout = 600;
			dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
		}

		private void CheckTeaDuty()
		{
			checkTeaDutyCommand = "RecTeacherWorkingDaysPerWeek";
			dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper(checkTeaDutyCommand);
			dbCommandWrapper.CommandTimeout = 180;
			dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
		}

        private void RunDefault()
        {
            dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper("RunDefault");
            dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
        }

        private void FillContiAbsentStudent()
        {
            dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper("FillContiAbsentStudent", DateTime.Now);
            dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
        }

		private void SaveTeaAlternate()
		{
			saveAlternateCommand = "SaveAlternate";
			dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper(saveAlternateCommand);
			dbCommandWrapper.CommandTimeout = 180;
			dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
		}

        private void RunTeacherAbsenceMgmt()
        {
            dbCommandWrapper = dbPrepareForCheck.GetStoredProcCommandWrapper("TeacherAbsenceMgmt");
            dbPrepareForCheck.ExecuteNonQuery(dbCommandWrapper);
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
				if ( dbPrepareForCheck != null )
					dbPrepareForCheck = null;
			}
		}
	}
}
