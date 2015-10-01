using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using CPTT.BusinessRule;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuBaseInfoPrintSystem 的摘要说明。
	/// </summary>
	public class StuBaseInfoPrintSystem
	{
		private Students students;
		private Image getPicture;
		private bool needPrintPicture;
		private StuBaseInfoPrintRules stuBaseInfoPrintRules;
		public StuBaseInfoPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			students = new Students();
			stuBaseInfoPrintRules = new StuBaseInfoPrintRules();
		}

		public bool NeedPrintPicture
		{
			get { return this.needPrintPicture; }
			set { this.needPrintPicture = value; }
		}
		
		public void SetName(string getName)
		{
			students.Name = getName;
		}

		public void SetEntryStatus(string getEntryStatus)
		{
			students.EntryStatus = getEntryStatus;
		}

		public void SetGender(string getGender)
		{
			students.Gender = getGender;
		}

		public void SetLeaveDate(DateTime getLeaveDate)
		{
			students.LeaveDate = getLeaveDate;
		}

		public void SetBirthday(DateTime getBirthday)
		{
			students.Birthday = getBirthday;
		}

		public void SetNumber(string getNumber)
		{
			students.Number = getNumber;
		}

		public void SetEntryDate(DateTime getEntryDate)
		{
			students.EntryDate = getEntryDate;
		}

		public void SetOrigin(string getOrigin)
		{
			students.Origin = getOrigin;
		}

		public void SetNationality(string getNationality)
		{
			students.Nationality = getNationality;
		}

		public void SetZipCode(string getZipCode)
		{
			students.ZipCode = getZipCode;
		}

		public void SetJieDao(string getJieDao)
		{
			students.JieDao = getJieDao;
		}

		public void SetLiWei(string getLiWei)
		{
			students.LiWei = getLiWei;
		}

		public void SetNative(string getNative)
		{
			students.Native = getNative;
		}

		public void SetFamilyAddr(string getFamilyAddr)
		{
			students.FamilyAddr = getFamilyAddr;
		}

		public void SetHuKouAddr(string getHuKouAddr)
		{
			students.HuKouAddr = getHuKouAddr;
		}

		public void SetSickHistory(string getSickHistory)
		{
			students.SickHistory = getSickHistory;
		}

		public void SetFatherName(string getFatherName)
		{
			students.FatherName = getFatherName;
		}

		public void SetFatherPhone(string getFatherPhone)
		{
			students.FatherPhone = getFatherPhone;
		}

		public void SetFatherWorkPlace(string getFatherWorkPlace)
		{
			students.FatherWorkPlace = getFatherWorkPlace;
		}

		public void SetMotherName(string getMotherName)
		{
			students.MotherName = getMotherName;
		}

		public void SetMotherPhone(string getMotherPhone)
		{
			students.MotherPhone = getMotherPhone;
		}

		public void SetMotherWorkPlace(string getMotherWorkPlace)
		{
			students.MotherWorkPlace = getMotherWorkPlace;
		}

		public void SetPicture(Image getPicture)
		{
			this.getPicture = getPicture;
		}

		private Image GetPicture()
		{
			return getPicture;
		}
		
		public void StuBaseInfoPrint(string savePath)
		{
			using ( System.IO.File.Create(@"c:\temp.jpg") ){}
			if ( NeedPrintPicture )
				GetPicture().Save(@"c:\temp.jpg",ImageFormat.Jpeg);
			stuBaseInfoPrintRules.SetNPrintPicture(NeedPrintPicture);
			stuBaseInfoPrintRules.StuBaseInfoPrint(students,savePath);
		}

		public void AllStuInfoPrint(DataSet dsExportData,string savePath)
		{
			stuBaseInfoPrintRules.AllStuInfoPrint(dsExportData,savePath);
		}
	}
}
