using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// FinanInfo 的摘要说明。
	/// </summary>
	public class FinanInfo
	{
		private int messRestoreDays;
		private int admRestoreDays;
		private double messCharge;
		private double admCharge;
		private double nightCharge;
		private double milkCharge;
		private double commCharge;
		private double extraCharge;
		private string remark;
		public FinanInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public int GetMessRestoreDays
		{
			get { return this.messRestoreDays; }
			set { this.messRestoreDays = value; }
		}

		public int GetAdmRestoreDays
		{
			get { return this.admRestoreDays; }
			set { this.admRestoreDays = value; }
		}

		public double GetMessCharge
		{
			get { return this.messCharge; }
			set { this.messCharge = value; }
		}

		public double GetAdmCharge
		{
			get { return this.admCharge; }
			set { this.admCharge = value; }
		}

		public double GetNightCharge
		{
			get { return this.nightCharge; }
			set { this.nightCharge = value; }
		}

		public double GetMilkCharge
		{
			get { return this.milkCharge; }
			set { this.milkCharge = value; }
		}

		public double GetCommCharge
		{
			get { return this.commCharge; }
			set { this.commCharge = value; }
		}

		public double GetExtraCharge
		{
			get { return this.extraCharge; }
			set { this.extraCharge = value; }
		}  

		public string GetRemark
		{
			get { return this.remark; }
			set { this.remark = value; }
		}

	}
}
