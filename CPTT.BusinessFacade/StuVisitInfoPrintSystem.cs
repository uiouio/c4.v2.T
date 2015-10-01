using System;
using System.Data;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuVisitInfoPrintSystem 的摘要说明。
	/// </summary>
	public class StuVisitInfoPrintSystem
	{
		private StuVisitInfoPrintRules stuVisitInfoPrintRules;
		public StuVisitInfoPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			stuVisitInfoPrintRules = new StuVisitInfoPrintRules();
		}

		public void VisitInfoPrint(DataSet dsAbsDetailInfo,DateTime getBegDate,DateTime getEndDate,string savePath)
		{
			stuVisitInfoPrintRules.VisitInfoPrint(dsAbsDetailInfo,getBegDate,getEndDate,savePath);
		}
	}
}
