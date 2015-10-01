using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.BusinessRule;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FoodManagementSystem 的摘要说明。
	/// </summary>
	public class FoodManagementSystem
	{
		private FoodManagementRules foodManagementRules;
		public FoodManagementSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			foodManagementRules = new FoodManagementRules();
		}

		public DataSet GetFoodCategory()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DoGetFoodCategory();
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetFoodNutrition(string getFoodCateName,string getFoodNutName)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DoGetFoodNutrition(getFoodCateName,getFoodNutName);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetAccFood(string getFoodCateName,string getFoodName,string getBegDate,string getEndDate)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DoGetAccFood(getFoodCateName,getFoodName,getBegDate,getEndDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetFoodArrangement()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.GetFoodArrangement();
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetFoodArrName()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.GetFoodArrName();
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int InsertNutrition()
		{
			return foodManagementRules.doInsertNutrition();
		}

		public int DeleteNutrition()
		{
			return foodManagementRules.doDeleteNutrition();
		}

		public int UpdateNutrition()
		{
			return foodManagementRules.doUpdateNutrition();
		}

		public int InsertAccFood(string getFoodID,string getTakeAmount,string getDate,string getRemark)
		{
			return foodManagementRules.doInsertAccFood(getFoodID,getTakeAmount,getDate,getRemark);
		}

		public int UpdateAccFood(string getFoodID,string getTakeAmount,string getDate,string getRemark)
		{
			return foodManagementRules.doUpdateAccFood(getFoodID,getTakeAmount,getDate,getRemark);
		}

		public int DeleteAccFood(string getFoodID,string getDate)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DeleteAccFood(getFoodID,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int InsertFoodArrMeal()
		{
			return foodManagementRules.doInsertFoodArrMeal();
		}

		public int UpdateFoodArrMeal()
		{
			return foodManagementRules.doUpdateFoodArrMeal();
		}

		public int DeleteFoodArrMeal()
		{
			return foodManagementRules.doDeleteFoodArrMeal();
		}

		public DataSet GetFoodArrGrade(bool selStyle)
		{
			return foodManagementRules.doGetFoodArrGrade(selStyle);
		}

		public int UpdateFoodArrGrade()
		{
			return foodManagementRules.doUpdateFoodArrGrade();
		}

		public bool isValidProtein(string getProtein)
		{
			return foodManagementRules.CheckProtein(getProtein);
		}

		public bool isValidFat(string getFat)
		{
			return foodManagementRules.CheckFat(getFat);
		}

		public bool isValidCarbohydrate(string getCarbohydrate)
		{
			return foodManagementRules.CheckCarbohydrate(getCarbohydrate);
		}

		public bool isValidEnery(string getEnergy)
		{
			return foodManagementRules.CheckEnergy(getEnergy);
		}

		public void GetFoodName(string getFoodName)
		{
			foodManagementRules.SetFoodName(getFoodName);
		}

		public void GetFoodCategory(string getCategory)
		{
			foodManagementRules.SetFoodCategory(getCategory);
		}

		public void GetFoodRemark(string getRemark)
		{
			foodManagementRules.SetFoodRemark(getRemark);
		}

		public void GetFoodID(int getFoodID)
		{
			foodManagementRules.SetFoodID(getFoodID);
		}

		public void GetFoodArrID(string getFoodArrID)
		{
			foodManagementRules.SetFoodArrID(Convert.ToInt32(getFoodArrID));
		}

		public void GetMealName(string getMealName)
		{
			foodManagementRules.SetMealName(getMealName);
		}

		public void GetMealRemark(string getMealRemark)
		{
			foodManagementRules.SetMealRemark(getMealRemark);
		}

		public void HasBreakFast(bool hasBreakFast)
		{
			foodManagementRules.HasBreakFast(hasBreakFast);
		}

		public void HasLunch(bool hasLunch)
		{
			foodManagementRules.HasLunch(hasLunch);
		}

		public void HasSnack(bool hasSnack)
		{
			foodManagementRules.HasSnack(hasSnack);
		}

		public void HasDinner(bool hasDinner)
		{
			foodManagementRules.HasDinner(hasDinner);
		}

		public void GetSuitAge(string getSuitAge)
		{
			foodManagementRules.SetSuitAge(getSuitAge);
		}

		public void IsUsed(string isUsed)
		{
			foodManagementRules.SetIsUsed(isUsed);
		}

		public void GetFoodArrName(string getFoodArrName)
		{
			foodManagementRules.SetFoodArrName(getFoodArrName);
		}

	}
}
