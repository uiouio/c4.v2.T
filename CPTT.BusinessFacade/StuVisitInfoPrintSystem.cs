using System;
using System.Data;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuVisitInfoPrintSystem ��ժҪ˵����
	/// </summary>
	public class StuVisitInfoPrintSystem
	{
		private StuVisitInfoPrintRules stuVisitInfoPrintRules;
		public StuVisitInfoPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			stuVisitInfoPrintRules = new StuVisitInfoPrintRules();
		}

		public void VisitInfoPrint(DataSet dsAbsDetailInfo,DateTime getBegDate,DateTime getEndDate,string savePath)
		{
			stuVisitInfoPrintRules.VisitInfoPrint(dsAbsDetailInfo,getBegDate,getEndDate,savePath);
		}
	}
}
