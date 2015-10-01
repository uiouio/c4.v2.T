using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuVisitInfoRule 的摘要说明。
	/// </summary>
	public class StuVisitInfoRule
	{
		StuVisit stuVisit;
		public StuVisitInfoRule()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			stuVisit = new StuVisit();
		}

		public string GetAbsDetail(int stuNumber,DateTime getDate)
		{
			string absDetail = string.Empty;
			DataSet dsAbsDetail;
			using ( StuVisitInfoDataAccess stuVisitInfoDataAcess = new StuVisitInfoDataAccess() )
			{
				try
				{
					dsAbsDetail = stuVisitInfoDataAcess.SetAbsentDaysInMonth(stuNumber,getDate);
					absDetail = "该幼儿本月连续缺勤2天累积天数为: "+stuVisitInfoDataAcess.GetAbsSum.ToString()+"天！"
						+"\t\t具体情况为:\t\t\t\t\t"; 
					foreach(DataRow absDetailRow in dsAbsDetail.Tables[0].Rows)
					{
						absDetail += "统计日期: "+Convert.ToDateTime(absDetailRow[1]).ToString("yyyy-MM-dd")
							+"\t\t\t\t统计结果: "+"该幼儿从上个出勤日截止到统计日"
							+"\t\t\t连续缺勤 "+absDetailRow[2].ToString()+" 天\t\t\t\t";
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
			return absDetail;
		}

		public int DoAbsenceInfoInsert()
		{
			using (StuVisitInfoDataAccess stuVisitInfoDataAccess = new StuVisitInfoDataAccess())
			{
				try
				{
					return stuVisitInfoDataAccess.DoAbsenceInfoInsert(stuVisit);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public void DoAbsenceDelete()
		{
			using (StuVisitInfoDataAccess stuVisitInfoDataAccess = new StuVisitInfoDataAccess())
			{
				try
				{
					stuVisitInfoDataAccess.DoAbsenceInfoDelete(stuVisit);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public void DoAbsenceUpdate()
		{
			using (StuVisitInfoDataAccess stuVisitInfoDataAccess = new StuVisitInfoDataAccess())
			{
				try
				{
					stuVisitInfoDataAccess.DoAbsenceInfoUpdate(stuVisit);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public void SetStuNumber(int getNumber)
		{
			stuVisit.StuNumber = getNumber;
		}

		public void SetAbsReason(string getReason)
		{
			stuVisit.AbsReason = getReason;
		}

		public void SetVisitMode(string getMode)
		{
			stuVisit.VisitMode = getMode;
		}

		public void SetVisitDate(DateTime getDate)
		{
			stuVisit.VisitDate = getDate;
		}

		public void SetVisitTeaSign(string getSign)
		{
			stuVisit.VisitTeaSign = getSign;
		}

		public void SetAbsRemark(string getRemark)
		{
			stuVisit.AbsRemark = getRemark;
		}

		public void GetAbsReason(string getReason)
		{
			stuVisit.GetAbsReason = getReason;
		}

		public void GetVisitMode(string getMode)
		{
			stuVisit.GetVisitMode = getMode;
		}

		public void GetVisitDate(DateTime getDate)
		{
			stuVisit.GetVisitDate = getDate;
		}

		public void GetVisitTeaSign(string getSign)
		{
			stuVisit.GetVisitTeaSign = getSign;
		}
		
		public void GetAbsRemark(string getRemark)
		{
			stuVisit.GetAbsRemark = getRemark;
		}
	}
}
