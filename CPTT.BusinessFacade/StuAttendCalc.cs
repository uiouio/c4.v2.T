using System;
using CPTT.DataAccess;
using CPTT.BusinessRule;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuAttendCalcForSolo 的摘要说明。
	/// </summary>
	public class StuAttendCalc
	{
		private StuAttendCalcRules stuAttendCalcRules = new StuAttendCalcRules();
		public StuAttendCalc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region 用户控件返回内容
		public string GetHealthAttend(bool isForClass)
		{
			return  stuAttendCalcRules.SetHealthAttend(isForClass);
		}

		public string GetIllAttend(bool isForClass)
		{
			return stuAttendCalcRules.SetIllAttend(isForClass);
		}

		public string GetWatchAttend(bool isForClass)
		{
			return stuAttendCalcRules.SetWatchAttend(isForClass);
		}

		public string GetAbsence(bool isForClass)
		{
			return stuAttendCalcRules.SetAbsence(isForClass);
		}

		public string GetHaveAttended(bool isForClass)
		{
			return stuAttendCalcRules.SetHaveAttended(isForClass);
		}

		public string GetShouldAttend(bool isForClass)
		{
			return stuAttendCalcRules.SetShouldAttend(isForClass);
		}

		public string GetDayAmount()
		{
			return stuAttendCalcRules.SetDayAmount();
		}

		public string HasGoneNumber()
		{
			return stuAttendCalcRules.HasGone();
		}

		public string HasnotGoneNumber()
		{
			return stuAttendCalcRules.HasnotGone();
		}

		public string ShouldGo()
		{
			return stuAttendCalcRules.ShouldGo();
		}

		#endregion

		public void GetStuAttendCalcForClass(string getGrade,string getClass,string getBegTime,
			string getEndTime,string getState)
		{
			try
			{
				stuAttendCalcRules.SetStuAttendCalcForClass(getGrade,getClass,getBegTime,getEndTime,getState);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}

		public void GetStuAttendCalcForSolo(string getName,string getNumber,string getBegTime,
			string getEndTime,string getState)
		{
			try
			{
				stuAttendCalcRules.SetStuAttendCalcForSolo(getName,getNumber,getBegTime,getEndTime,getState);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}

		public void DoStuBackCalc(string getGrade,string getClass,string getName,string getNumber,string getBegTime,
			string getEndTime)
		{
			try
			{
				stuAttendCalcRules.SetStuBackCalc(getGrade,getClass,getName,getNumber,getBegTime,getEndTime);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}

	}
}
