using System;
using System.Data;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;


namespace CPTT.BusinessRule
{
	/// <summary>
	/// FoodManagementRules 的摘要说明。
	/// </summary>
	public class FoodManagementRules
	{
		private FoodMgmt foodMgmt;
		public FoodManagementRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			foodMgmt = new FoodMgmt();
		}

		//食物营养保存
		public int doInsertNutrition()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.InsertNutrition(foodMgmt);	
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		//食物营养删除
		public int doDeleteNutrition()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DeleteNutrition(foodMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		//食物营养修改
		public int doUpdateNutrition()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.UpdateNutrition(foodMgmt);
				}	
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		//每日食谱保存
		public int doInsertAccFood(string getFoodID,string getTakeAmount,string getDate,string getRemark)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					double takeAmount = Convert.ToDouble(getTakeAmount);
					return foodManagementDataAccess.InsertAccFood(getFoodID,takeAmount,getDate,getRemark);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int doUpdateAccFood(string getFoodID,string getTakeAmount,string getDate,string getRemark)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					double takeAmount = Convert.ToDouble(getTakeAmount);
					return foodManagementDataAccess.UpdateAccFood(getFoodID,takeAmount,getDate,getRemark);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int doInsertFoodArrMeal()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.InsertFoodArrMeal(foodMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int doUpdateFoodArrMeal()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.UpdateFoodArrMeal(foodMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int doDeleteFoodArrMeal()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.DeleteFoodArrMeal(foodMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public DataSet doGetFoodArrGrade(bool selStyle)
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.GetFoodArrGrade(foodMgmt,selStyle);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int doUpdateFoodArrGrade()
		{
			using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
			{
				try
				{
					return foodManagementDataAccess.UpdateFoodArrGrade(foodMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		//检验蛋白质的有效性
		public bool CheckProtein(string getProtein)
		{
			try
			{
				foodMgmt.Protein = Convert.ToDouble(getProtein);
				return true;
			}
			catch
			{
				return false;
			}
		}

		//检验脂肪的有效性
		public bool CheckFat(string getFat)
		{
			try
			{
				foodMgmt.Fat = Convert.ToDouble(getFat);
				return true;
			}
			catch
			{
				return false;
			}
		}

		//检验碳水化合物的有效性
		public bool CheckCarbohydrate(string getCarbohydrate)
		{
			try
			{
				foodMgmt.Carbohydrate = Convert.ToDouble(getCarbohydrate);
				return true;
			}
			catch
			{
				return false;
			}
		}

		//检验能量的有效性
		public bool CheckEnergy(string getEnergy)
		{
			try
			{
				foodMgmt.Energy = Convert.ToDouble(getEnergy);
				return true;
			}
			catch
			{
				return false;
			}
		}

		//食物库存食物名
		public void SetFoodName(string getFoodName)
		{
			foodMgmt.FoodName = getFoodName;
		}

		//食物库存食物类别
		public void SetFoodCategory(string getCategory)
		{
			foodMgmt.FoodCategory = getCategory;
		}

		//食物库存食物备注
		public void SetFoodRemark(string getFoodRemark)
		{
			foodMgmt.FoodRemark = getFoodRemark;
		}

		//食物库存食物ID
		public void SetFoodID(int getFoodID)
		{
			foodMgmt.FoodID = getFoodID;
		}

		//膳食编号
		public void SetFoodArrID(int getFoodArrID)
		{
			foodMgmt.FoodArrID = getFoodArrID;
		}

		//膳食名称
		public void SetMealName(string getMealName)
		{
			foodMgmt.MealName = getMealName;
		}

		//膳食备注
		public void SetMealRemark(string getMealRemark)
		{
			foodMgmt.MealRemark = getMealRemark;
		}

		//是否启用早餐
		public void HasBreakFast(bool hasBreakFast)
		{
			foodMgmt.BreakFast = hasBreakFast;
		}

		//是否启用午餐
		public void HasLunch(bool hasLunch)
		{
			foodMgmt.Lunch = hasLunch;
		}

		//是否启用点心
		public void HasSnack(bool hasSnack)
		{
			foodMgmt.Snack = hasSnack;
		}

		//是否启用晚餐
		public void HasDinner(bool hasDinner)
		{
			foodMgmt.Dinner = hasDinner;
		}

		public void SetSuitAge(string getSuitAge)
		{
			foodMgmt.SuitAge = getSuitAge;
		}

		public void SetIsUsed(string isUsed)
		{
			foodMgmt.IsUsed = isUsed;
		}

		public void SetFoodArrName(string getFoodArrName)
		{
			foodMgmt.FoodArrName = getFoodArrName;
		}
	}
}
