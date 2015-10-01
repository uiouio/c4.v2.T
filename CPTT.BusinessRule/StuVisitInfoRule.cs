using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuVisitInfoRule ��ժҪ˵����
	/// </summary>
	public class StuVisitInfoRule
	{
		StuVisit stuVisit;
		public StuVisitInfoRule()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
					absDetail = "���׶���������ȱ��2���ۻ�����Ϊ: "+stuVisitInfoDataAcess.GetAbsSum.ToString()+"�죡"
						+"\t\t�������Ϊ:\t\t\t\t\t"; 
					foreach(DataRow absDetailRow in dsAbsDetail.Tables[0].Rows)
					{
						absDetail += "ͳ������: "+Convert.ToDateTime(absDetailRow[1]).ToString("yyyy-MM-dd")
							+"\t\t\t\tͳ�ƽ��: "+"���׶����ϸ������ս�ֹ��ͳ����"
							+"\t\t\t����ȱ�� "+absDetailRow[2].ToString()+" ��\t\t\t\t";
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
