using System;
using System.Data;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FinanMgmtInfoPrintSystem ��ժҪ˵����
	/// </summary>
	public class FinanMgmtInfoPrintSystem
	{
		private FinanMgmtInfoPrintRules finanMgmtInfoPrintRules;
		public FinanMgmtInfoPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			finanMgmtInfoPrintRules = new FinanMgmtInfoPrintRules();
		}

		public void FinanMgmtInfoPrint(DataSet dsFinanInfo,string savePath)
		{
			finanMgmtInfoPrintRules.FinanMgmtInfoPrint(dsFinanInfo,savePath);
		}

		public void FinanceStatPrint(DataTable data, string className, DateTime date, string savePath)
		{
			finanMgmtInfoPrintRules.FinanceStatPrint(data, className, date, savePath);
		}
	}
}
