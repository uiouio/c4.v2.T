using System;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FoodManagementPrintSystem 的摘要说明。
	/// </summary>
	public class FoodManagementPrintSystem
	{
		private FoodManagementPrintRules foodManagementPrintRules;

		public FoodManagementPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
