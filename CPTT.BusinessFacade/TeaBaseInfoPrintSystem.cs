using System;
using System.Drawing;
using System.Drawing.Imaging;
using CPTT.SystemFramework;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TeaBaseInfoPrintSystem 的摘要说明。
	/// </summary>
	public class TeaBaseInfoPrintSystem
	{
		private TeacherBase tBase;
		private TeaBaseInfoPrintRules teaBaseInfoPrintRules;
		private bool needPrintPicture;
		private Image getPicture;
		public TeaBaseInfoPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			tBase = new TeacherBase();
			teaBaseInfoPrintRules = new TeaBaseInfoPrintRules();
		}

		public bool NeedPrintPicture
		{
			get { return this.needPrintPicture; }
			set { this.needPrintPicture = value; }
		}

		public void SetName(string getName)
		{
			tBase.TName = getName;
		}

		public void SetGender(string getGender)
		{
			tBase.TSex = getGender;
		}

		public void SetDegree(string getDegree)
		{
			tBase.TCareer = getDegree;
		}

		public void SetHomeTel(string getHomeTel)
		{
			tBase.THomeTel = getHomeTel;
		}

		public void SetPhone(string getPhone)
		{
			tBase.TPhone = getPhone;
		}

		public void SetWorkTel(string getWorkTel)
		{
			tBase.TWorkTel = getWorkTel;
		}

		public void SetMarriage(string getMarriage)
		{
			tBase.TMerrige = getMarriage;
		}

		public void SetAddr(string getAddr)
		{
			tBase.TAddr = getAddr;
		}

		public void SetDept(string getDept)
		{
			tBase.TDepart = getDept;
		}

		public void SetDuty(string getDuty)
		{
			tBase.TDuty = getDuty;
		}

		public void SetJobEva(string getJobEva)
		{
			tBase.TTechnicalPost = getJobEva;
		}

		public void SetLevel(string getLevel)
		{
			tBase.TLevel = getLevel;
		}

		public void SetWorkDate(DateTime getWorkDate)
		{
			tBase.TWorkTime = getWorkDate;
		}

		public void SetEnterDate(DateTime getEnterDate)
		{
			tBase.TEnterTime = getEnterDate;
		}

		public void SetPicture(Image getPicture)
		{
			this.getPicture = getPicture;
		}

		private Image GetPicture()
		{
			return getPicture;
		}
		
		public void TeaBaseInfoPrint(string savePath)
		{
			using ( System.IO.File.Create(@"c:\temp.jpg") )
			{}
			if ( NeedPrintPicture )
				GetPicture().Save(@"c:\temp.jpg",ImageFormat.Jpeg);
			teaBaseInfoPrintRules.SetNPrintPicture(NeedPrintPicture);
			teaBaseInfoPrintRules.PrintTeaBaseInfo(tBase,savePath);
		}

	}
}
