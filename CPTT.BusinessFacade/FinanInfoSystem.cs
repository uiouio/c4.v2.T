using System;
using System.Collections;
using System.Data;
using CPTT.BusinessRule;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FinanInfoSystem 的摘要说明。
	/// </summary>
	public class FinanInfoSystem
	{
		private FinanInfoRules finanInfoRules;
		private FinanInfo finanInfo;
		public FinanInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			finanInfoRules = new FinanInfoRules();
			finanInfo = new FinanInfo();
		}

		public DataSet GetContiAbsForMessDetail(string getGrade,string getClass,string getName,
			string getNumber,DateTime balanceMonth)
		{
			return finanInfoRules.GetContiAbsForMess(getGrade,getClass,getName,getNumber,
				balanceMonth,finanInfo);
		}

		public DataSet GetFinanInfo(DataSet getDS,string getNumber,DateTime balanceMonth)
		{
			return finanInfoRules.ModifyFinanInfo(finanInfo,getDS,getNumber,balanceMonth);
		}

		public void InsertFinanInfo(DataSet dsFinanInfo,DateTime getDate,int getMessRestoreDays,int getAdmRestoreDays)
		{
			finanInfoRules.DoInsertFinanInfo(dsFinanInfo,getDate,getMessRestoreDays,getAdmRestoreDays);
		}

		public void DeleteFinanInfo(DateTime getDate)
		{
			finanInfoRules.DoDeleteFinanInfo(getDate);
		}

		public DataSet GetFinanInfoHistoryInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			using ( FinanInfoDataAccess finanInfoDataAccess = new FinanInfoDataAccess() )
			{
				try
				{
					return finanInfoDataAccess.GetFinanHistoryInfo(getGrade,getClass,getName,getNumber,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void SetMessRestoreDays(int messRestoreDays)
		{
			finanInfo.GetMessRestoreDays = messRestoreDays;
		}

		public void SetAdmRestoreDays(int admRestoreDays)
		{
			finanInfo.GetAdmRestoreDays = admRestoreDays;
		}

		public void SetMessCharge(double messCharge)
		{
			finanInfo.GetMessCharge = messCharge;
		}

		public void SetAdmCharge(double admCharge)
		{
			finanInfo.GetAdmCharge = admCharge;
		}

		public void SetNightCharge(double nightCharge)
		{
			finanInfo.GetNightCharge = nightCharge;
		}

		public void SetMilkCharge(double milkCharge)
		{
			finanInfo.GetMilkCharge = milkCharge;
		}

		public void SetCommCharge(double commCharge)
		{
			finanInfo.GetCommCharge = commCharge;
		}

		public void SetExtraCharge(double extraCharge)
		{
			finanInfo.GetExtraCharge = extraCharge;
		}

		public void SetRemark(string remark)
		{
			finanInfo.GetRemark = remark;
		}

		public DataTable GetTemplate(string templateName)
		{
			try
			{
				using (DataTable dtTemplate = new FinanInfoDataAccess().GetTemplate(templateName))
				{
					return dtTemplate;
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataTable GetTemplateContents(string templateName)
		{
			try
			{
				using (DataTable dtTemplateContents = new FinanInfoDataAccess().GetTemplateContents(templateName))
				{
					return dtTemplateContents;
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public void DeleteTemplate(string templateName)
		{
			try
			{
				new FinanInfoDataAccess().DeleteTemplate(templateName);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				throw ex;
			}
		}

		public void AddTemplateContents(int templateId, string tempalteName, DataRow drTemplateContents, DateTime date)
		{
			try
			{
				new FinanInfoDataAccess().AddTemplateContents(templateId, tempalteName, drTemplateContents, date);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				throw ex;
			}
		}

		public void DeleteTemplateContents(string name, string grade, string className, int templateId, DateTime date)
		{
			try
			{
				new FinanInfoDataAccess().DeleteTemplateContents(name, grade, className, templateId, date);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				throw ex;
			}
		}

		public DataTable MakingFinanceStat(string templateName, string grade, string className, DateTime date, out ArrayList list)
		{
			return new FinanInfoRules().MakingFinanceStat(templateName, grade, className, date, out list);
		}

		public void AddFinanceStatTable(string templateName, DataColumnCollection columns)
		{
			try
			{
				new FinanInfoDataAccess().AddFinanceStatTable(templateName, columns);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				throw ex;
			}
		}

		public void AddFinanceStatHistory(DataTable dtStat, string templateName, DateTime date)
		{
			try
			{
				new FinanInfoDataAccess().AddFinanceStatHistory(dtStat, templateName, date);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				throw ex;
			}
		}
		
		public bool IsFinanceStatExisted(string templateName)
		{
			try
			{
				DataTable dt = new FinanInfoDataAccess().IsFinanceStatExisted(templateName);
				if (dt != null && dt.Rows.Count > 0)
				{
					return Convert.ToInt32(dt.Rows[0][0]) == 1;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				return false;
			}
		}

		public DataTable GetFinanceStatHistory(string templateName, string className, DateTime date)
		{
			try
			{
				using (DataTable dt = new FinanInfoDataAccess().GetFinanceStatHistory(templateName, className, date))
				{
					return dt;
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataTable FilterTemplateContents(string templateName, string grade, string className)
		{
			return new FinanInfoRules().FilterTemplateContents(templateName, grade, className);
		}
	}
}
