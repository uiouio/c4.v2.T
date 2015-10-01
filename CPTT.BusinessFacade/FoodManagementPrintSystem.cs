using System;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FoodManagementPrintSystem ��ժҪ˵����
	/// </summary>
	public class FoodManagementPrintSystem
	{
		private FoodManagementPrintRules foodManagementPrintRules;

		public FoodManagementPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			foodManagementPrintRules = new FoodManagementPrintRules();
		}
		
		public void NutritionPrint(DateTime getBegDate,DateTime getEndDate,string savePath)
		{
			foodManagementPrintRules.BegDate = getBegDate;
			foodManagementPrintRules.EndDate = getEndDate;
			foodManagementPrintRules.NutritionPrint(savePath);
		}

	}
}
