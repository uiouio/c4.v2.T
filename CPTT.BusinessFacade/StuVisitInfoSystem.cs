using System;
using System.Data;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;
namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuVisitInfo 的摘要说明。
	/// </summary>
	public class StuVisitInfoSystem
	{
		StuVisitInfoRule stuVisitInfoRule;
		public StuVisitInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			stuVisitInfoRule = new StuVisitInfoRule();
		}

		public DataSet Get2DaysAbsence(string getGrade,string getClass,DateTime getDate)
		{
			using ( StuVisitInfoDataAccess stuVisitInfoDataAccess = new StuVisitInfoDataAccess() )
			{
				try
				{
					return stuVisitInfoDataAccess.Set2DaysAbs(getGrade,getClass,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetAbsenceDetail(string getGrade,string getClass,string getName,string getNumber,
			DateTime getBegDate,DateTime getEndDate)
		{
			using ( StuVisitInfoDataAccess stuVisitInfoDataAccess = new StuVisitInfoDataAccess() )
			{
				try
				{
					return stuVisitInfoDataAccess.SetAbsenceDetail(getGrade,getClass,getName,getNumber,
						getBegDate,getEndDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int DoAbsenceInfoInsert()
		{
			return stuVisitInfoRule.DoAbsenceInfoInsert();
		}

		public void DoAbsenceInfoDelete()
		{
			stuVisitInfoRule.DoAbsenceDelete();
		}

		public void DoAbsenceInfoUpdate()
		{
			stuVisitInfoRule.DoAbsenceUpdate();
		}

		public string GetAbsenceDetailInMonth(int getNumber,DateTime getDate)
		{
			return stuVisitInfoRule.GetAbsDetail(getNumber,getDate);
		}

		public void GetNumber(int getNumber)
		{
			stuVisitInfoRule.SetStuNumber(getNumber);
		}

		public void GetReason(string getReason)
		{
			stuVisitInfoRule.SetAbsReason(getReason);
		}

		public void GetMode(string getMode)
		{
			stuVisitInfoRule.SetVisitMode(getMode);
		}

		public void GetDate(DateTime getDate)
		{
			stuVisitInfoRule.SetVisitDate(getDate);
		}

		public void GetSign(string getSign)
		{
			stuVisitInfoRule.SetVisitTeaSign(getSign);
		}

		public void GetRemark(string getRemark)
		{
			stuVisitInfoRule.SetAbsRemark(getRemark);
		}

		public void GetSourceReason(string getReason)
		{
			stuVisitInfoRule.GetAbsReason(getReason);
		}

		public void GetSourceMode(string getMode)
		{
			stuVisitInfoRule.GetVisitMode(getMode);
		}

		public void GetSourceDate(DateTime getDate)
		{
			stuVisitInfoRule.GetVisitDate(getDate);
		}

		public void GetSourceSign(string getSign)
		{
			stuVisitInfoRule.GetVisitTeaSign(getSign);
		}

		public void GetSourceRemark(string getRemark)
		{
			stuVisitInfoRule.GetAbsRemark(getRemark);
		}
	}
}
