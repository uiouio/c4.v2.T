using System;
using System.Data;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;


namespace CPTT.BusinessRule
{
	/// <summary>
	/// FoodManagementRules ��ժҪ˵����
	/// </summary>
	public class FoodManagementRules
	{
		private FoodMgmt foodMgmt;
		public FoodManagementRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			foodMgmt = new FoodMgmt();
		}

		//ʳ��Ӫ������
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

		//ʳ��Ӫ��ɾ��
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

		//ʳ��Ӫ���޸�
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

		//ÿ��ʳ�ױ���
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

		//���鵰���ʵ���Ч��
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

		//����֬������Ч��
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

		//����̼ˮ���������Ч��
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

		//������������Ч��
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

		//ʳ����ʳ����
		public void SetFoodName(string getFoodName)
		{
			foodMgmt.FoodName = getFoodName;
		}

		//ʳ����ʳ�����
		public void SetFoodCategory(string getCategory)
		{
			foodMgmt.FoodCategory = getCategory;
		}

		//ʳ����ʳ�ﱸע
		public void SetFoodRemark(string getFoodRemark)
		{
			foodMgmt.FoodRemark = getFoodRemark;
		}

		//ʳ����ʳ��ID
		public void SetFoodID(int getFoodID)
		{
			foodMgmt.FoodID = getFoodID;
		}

		//��ʳ���
		public void SetFoodArrID(int getFoodArrID)
		{
			foodMgmt.FoodArrID = getFoodArrID;
		}

		//��ʳ����
		public void SetMealName(string getMealName)
		{
			foodMgmt.MealName = getMealName;
		}

		//��ʳ��ע
		public void SetMealRemark(string getMealRemark)
		{
			foodMgmt.MealRemark = getMealRemark;
		}

		//�Ƿ��������
		public void HasBreakFast(bool hasBreakFast)
		{
			foodMgmt.BreakFast = hasBreakFast;
		}

		//�Ƿ��������
		public void HasLunch(bool hasLunch)
		{
			foodMgmt.Lunch = hasLunch;
		}

		//�Ƿ����õ���
		public void HasSnack(bool hasSnack)
		{
			foodMgmt.Snack = hasSnack;
		}

		//�Ƿ��������
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
