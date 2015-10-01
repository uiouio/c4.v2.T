using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// Option 的摘要说明。
	/// </summary>
	public class Option
	{
		private string stuID;
		private string stuNumber;
		private string stuName;
		private string stuGrade;
		private string stuClass;
		private string stuPhone;
		private string stuFamilyAddr;
		private DateTime stuBirthday;
		private DateTime stuEnterDate;
		private string stuEmail;
		private string stuZipCode;
		private string stuGender;
		private string stuEntryStatus;
		private string gradeName;
		private string gradeRemark;
		private string className;
		private string teaID;
		private string teaNumber;
		private string teaName;
		private string teaDept;
		private string teaDuty;
		private string teaAuthority;
		private string teaGender;
		private string teaOfficePhone;
		public Option()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string StuID
		{
			get { return this.stuID; }
			set { this.stuID = value; }
		}

		public string StuNumber
		{
			get { return this.stuNumber; }
			set { this.stuNumber = value; }
		}

		public string StuName
		{
			get { return this.stuName; }
			set { this.stuName = value; }
		}

		public string StuGrade
		{
			get { return this.stuGrade; }
			set { this.stuGrade = value; }
		}

		public string StuClass
		{
			get { return this.stuClass; }
			set { this.stuClass = value; }
		}

		public string StuPhone
		{
			get { return this.stuPhone; }
			set { this.stuPhone = value; }
		}

		public string StuFamilyAddr
		{
			get { return this.stuFamilyAddr; }
			set { this.stuFamilyAddr = value; }
		}

		public DateTime StuBirthday
		{
			get { return this.stuBirthday; }
			set { this.stuBirthday = value; }
		}

		public DateTime StuEnterDate
		{
			get { return this.stuEnterDate; }
			set { this.stuEnterDate = value; }
		}

		public string StuEmail
		{
			get { return this.stuEmail; }
			set { this.stuEmail = value; }
		}

		public string StuZipCode
		{
			get { return this.stuZipCode; }
			set { this.stuZipCode = value; }
		}

		public string StuGender
		{
			get { return this.stuGender; }
			set { this.stuGender = value; }
		}

		public string StuEntryStatus
		{
			get { return this.stuEntryStatus; }
			set { this.stuEntryStatus = value;}
		}

        public string StuParent1
        {
            get;
            set;
        }

        public string StuParent1_Phone
        {
            get;
            set;
        }

        public string StuParent2
        {
            get;
            set;
        }

        public string StuParent2_Phone
        {
            get;
            set;
        }

		public string GradeName
		{
			get { return this.gradeName; }
			set { this.gradeName = value; }
		}

		public string GradeRemark
		{
			get { return this.gradeRemark; }
			set { this.gradeRemark = value; }
		}

		public string ClassName
		{
			get { return this.className; }
			set { this.className = value; }
		}

		public string TeaID
		{
			get { return this.teaID; }
			set { this.teaID = value; }
		}

		public string TeaName
		{
			get { return this.teaName; }
			set { this.teaName = value; }
		}

		public string TeaNumber
		{
			get { return this.teaNumber; }
			set { this.teaNumber = value; }
		}

		public string TeaDept
		{
			get { return this.teaDept; }
			set { this.teaDept = value; }
		}

		public string TeaDuty
		{
			get { return this.teaDuty; }
			set { this.teaDuty = value; } 
		}

		public string TeaAuthority
		{
			get { return this.teaAuthority; }
			set { this.teaAuthority = value; }
		}

		public string TeaGender
		{
			get { return this.teaGender; }
			set { this.teaGender = value; } 
		}

		public string TeaOfficePhone
		{
			get { return this.teaOfficePhone; }
			set { this.teaOfficePhone = value; }
		}
	}
}
