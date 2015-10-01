using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// FoodMgmt 的摘要说明。
	/// </summary>
	public class FoodMgmt 
	{
		private double getProtein;
		private double getFat;
		private double getCarbohydrate;
		private double getEnergy;
		private string getFoodCategory;
		private string getFoodRemark;
		private string getFoodName;
		private int getFoodID;
		private string getMealName;
		private string getMealRemark;
		private int getFoodArrID;
		private bool hasBreakFast;
		private bool hasLunch;
		private bool hasSnack;
		private bool hasDinner;
		private string getFoodArrName;
		private string getSuitAge;
		private string isUsed;
		public FoodMgmt()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public double Protein
		{
			get { return this.getProtein; }
			set { this.getProtein = value; } 
		}

		public double Fat
		{
			get { return this.getFat; }
			set { this.getFat = value; }
		}

		public double Carbohydrate
		{
			get { return this.getCarbohydrate; }
			set { this.getCarbohydrate = value; }
		}

		public double Energy
		{
			get { return this.getEnergy; }
			set { this.getEnergy = value; }
		}

		public string FoodCategory
		{
			get { return this.getFoodCategory; }
			set { this.getFoodCategory = value; }
		}

		public string FoodRemark
		{
			get { return this.getFoodRemark; }
			set { this.getFoodRemark = value; }
		}

		public string FoodName
		{
			get { return this.getFoodName; }
			set { this.getFoodName = value; }
		}

		public int FoodID
		{
			get { return this.getFoodID; }
			set { this.getFoodID = value; }
		}

		public int FoodArrID
		{
			get { return this.getFoodArrID; }
			set { this.getFoodArrID = value; }
		}

		public string MealName
		{
			get { return this.getMealName; }
			set { this.getMealName = value; }
		}

		public string MealRemark
		{
			get { return this.getMealRemark; }
			set { this.getMealRemark = value; }
		}

		public bool BreakFast
		{
			get { return this.hasBreakFast; }
			set { this.hasBreakFast = value; }
		}

		public bool Lunch
		{
			get { return this.hasLunch; }
			set { this.hasLunch = value; }
		}

		public bool Snack
		{
			get { return this.hasSnack; }
			set { this.hasSnack = value; }
		}

		public bool Dinner 
		{
			get { return this.hasDinner; }
			set { this.hasDinner = value; }
		}

		public string FoodArrName
		{
			get { return this.getFoodArrName; }
			set { this.getFoodArrName = value; }
		}

		public string SuitAge
		{
			get { return this.getSuitAge; }
			set { this.getSuitAge = value; }
		}
		
		public string IsUsed
		{
			get { return this.isUsed; }
			set { this.isUsed = value; }
		}
	}
}
