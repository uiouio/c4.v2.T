using System;


namespace CPTT.SystemFramework
{
	/// <summary>
	/// StuVisit 的摘要说明。
	/// </summary>
	public class StuVisit
	{
		private int stuNumber;
		private string absReason;
		private string visitMode;
		private DateTime visitDate;
		private string visitTeaSign;
		private string absRemark;
		private string getAbsReason;
		private string getVisitMode;
		private DateTime getVisitDate;
		private string getVisitTeaSign;
		private string getAbsRemark;
		public StuVisit()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int StuNumber
		{
			get { return this.stuNumber; }
			set { this.stuNumber = value; }
		}

		public string AbsReason
		{
			get { return this.absReason; }
			set { this.absReason = value; }
		}

		public string VisitMode
		{
			get { return this.visitMode; }
			set { this.visitMode = value; }
		}

		public DateTime VisitDate
		{
			get { return this.visitDate; }
			set { this.visitDate = value; }
		}

		public string VisitTeaSign
		{
			get { return this.visitTeaSign; }
			set { this.visitTeaSign = value; }
		}

		public string AbsRemark
		{
			get { return this.absRemark; }
			set { this.absRemark = value; }
		}

		public string GetAbsReason
		{
			get { return this.getAbsReason; }
			set { this.getAbsReason = value; }
		}

		public string GetVisitMode
		{
			get { return this.getVisitMode; }
			set { this.getVisitMode = value; }
		}

		public DateTime GetVisitDate
		{
			get { return this.getVisitDate; }
			set { this.getVisitDate = value; }
		}

		public string GetVisitTeaSign
		{
			get { return this.getVisitTeaSign; }
			set { this.getVisitTeaSign = value; }
		}

		public string GetAbsRemark
		{
			get { return this.getAbsRemark; }
			set { this.getAbsRemark = value; }
		}

	}
}
