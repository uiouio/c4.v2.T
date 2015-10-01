using System;
using System.Data;
namespace CPTT.SystemFramework
{
	/// <summary>
	/// Students 的摘要说明。
	/// </summary>
	public class Students
	{
		private string stuName;
		private string stuGender;
		private string stuEntryStatus;
		private DateTime stuLeaveDate;
		private DateTime stuBirthday;
		private string stuNumber;
		private DateTime stuEntryDate;
		private string stuOrigin;
		private string stuNationality;
		private string stuRegNote;
		private string stuJieDao;
		private string stuNative;
		private string stuZipCode;
		private string stuLiWei;
		private string stuBankID;
		private string stuEMail;
		private string stuSickHistory;
		private string stuFamilyAddr;
		private string stuHuKouAddr;
		private string stuFatherName;
		private string stuFatherPhone;
		private string stuFatherWorkPlace;
		private string stuMotherName;
		private string stuMotherPhone;
		private string stuMotherWorkPlace;
		private string stuGUID;
		private string stuClass;
		private string stuGrade;
		private byte[] stuGraphLocation;
		public Students()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 学生信息属性
		public string StuGuid
		{
			get{ return this.stuGUID;}
			set{ this.stuGUID = value;}
		}

		public string Name
		{
			get{ return this.stuName;}
			set{ this.stuName = value;}
		}

		public string Class
		{
			get{ return this.stuClass;}
			set{ this.stuClass = value;}
		}

		public string Grade
		{
			get{ return this.stuGrade;}
			set{ this.stuGrade = value;}
		}

		public string Gender
		{
			get{ return this.stuGender;}
			set{ this.stuGender = value;}
		}

		public string EntryStatus
		{
			get{ return this.stuEntryStatus;}
			set{ this.stuEntryStatus = value;}
		}

		public DateTime LeaveDate
		{
			get{ return this.stuLeaveDate;}
			set{ this.stuLeaveDate = value;}
		}

		public DateTime Birthday
		{
			get{ return this.stuBirthday;}
			set{ this.stuBirthday = value;}
		}

		public string Number
		{
			get{ return this.stuNumber;}
			set{ this.stuNumber = value;} 
		}

		public DateTime EntryDate
		{
			get{ return this.stuEntryDate;}
			set{ this.stuEntryDate = value;}
		}

		public string Origin
		{
			get{ return this.stuOrigin;}
			set{ this.stuOrigin = value;}
		}

		public string Nationality
		{
			get{ return this.stuNationality;}
			set{ this.stuNationality = value;}
		}
		
		public string RegNote
		{
			get{ return this.stuRegNote;}
			set{ this.stuRegNote = value;}
		}

		public string JieDao
		{
			get{ return this.stuJieDao;}
			set{ this.stuJieDao = value;}
		}

		public string Native
		{
			get{ return this.stuNative;}
			set{ this.stuNative = value;}
		}

		public string ZipCode
		{
			get{ return this.stuZipCode;}
			set{ this.stuZipCode = value;}
		}

		public string LiWei
		{
			get{ return this.stuLiWei;}
			set{ this.stuLiWei = value;}
		}

		public string BankID
		{
			get{ return this.stuBankID;}
			set{ this.stuBankID = value;}
		}

		public string EMail
		{
			get{ return this.stuEMail;}
			set{ this.stuEMail = value;}
		}
			
		public string SickHistory
		{
			get{ return this.stuSickHistory;}
			set{ this.stuSickHistory = value;}
		}

		public string FamilyAddr
		{
			get{ return this.stuFamilyAddr;}
			set{ this.stuFamilyAddr = value;}
		}

		public string HuKouAddr
		{
			get{ return this.stuHuKouAddr;}
			set{ this.stuHuKouAddr = value;}
		}

		public string FatherName
		{
			get{ return this.stuFatherName;}
			set{ this.stuFatherName = value;}
		}

		public string FatherPhone
		{
			get{ return this.stuFatherPhone;}
			set{ this.stuFatherPhone = value;}
		}

		public string FatherWorkPlace
		{
			get{ return this.stuFatherWorkPlace;}
			set{ this.stuFatherWorkPlace = value;}
		}

		public string MotherName
		{
			get{ return this.stuMotherName;}
			set{ this.stuMotherName = value;}
		}

		public string MotherPhone
		{
			get{ return this.stuMotherPhone;}
			set{ this.stuMotherPhone = value;}
		}	

		public string MotherWorkPlace
		{
			get{ return this.stuMotherWorkPlace;}
			set{ this.stuMotherWorkPlace = value;}
		}

		public byte[] GraphLocation
		{
			get{ return this.stuGraphLocation;}
			set{ this.stuGraphLocation = value;}
		}
		#endregion
	}
}
