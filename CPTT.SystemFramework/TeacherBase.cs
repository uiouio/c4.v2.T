//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// TeacherBase 的摘要说明。
	/// </summary>
	public class TeacherBase
	{
		private string tID;
		private string tNumber;
		private string tName;
		private string tSex;
		private string tMerrige;
		private string tAddr;
		private string tCareer;
		private string tHomeTel;
		private string tPhone;
		private string tWorkTel;
		private string tDepart;
		private string tDuty;
		private string tTechnicalPost;
		private string tLevel;
		private DateTime tWorkTime;
		private DateTime tEnterTime;
		private byte[] imageData;

		public TeacherBase()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string TID
		{
			get{return this.tID;}
			set{this.tID = value;}
		}

		public string TNumber
		{
			get{return this.tNumber;}
			set{this.tNumber = value;}
		}

		public string TName
		{
			get{return this.tName;}
			set{this.tName = value;}
		}

		public string TSex
		{
			get{return this.tSex;}
			set{this.tSex = value;}
		}

		public string TMerrige
		{
			get{return this.tMerrige;}
			set{this.tMerrige = value;}
		}

		public string TAddr
		{
			get{return this.tAddr;}
			set{this.tAddr = value;}
		}
		public string TCareer
		{
			get{return this.tCareer;}
			set{this.tCareer = value;}
		}

		public string THomeTel
		{
			get{return this.tHomeTel;}
			set{this.tHomeTel = value;}
		}

		public string TPhone
		{
			get{return this.tPhone;}
			set{this.tPhone = value;}
		}
		public string TWorkTel
		{
			get{return this.tWorkTel;}
			set{this.tWorkTel = value;}
		}

		public string TDepart
		{
			get{return this.tDepart;}
			set{this.tDepart = value;}
		}
		public string TDuty
		{
			get{return this.tDuty;}
			set{this.tDuty = value;}
		}

		public string TTechnicalPost
		{
			get{return this.tTechnicalPost;}
			set{this.tTechnicalPost = value;}
		}
		public string TLevel
		{
			get{return this.tLevel;}
			set{this.tLevel = value;}
		}

		public DateTime TWorkTime
		{
			get{return this.tWorkTime;}
			set{this.tWorkTime = value;}
		}

		public DateTime TEnterTime
		{
			get{return this.tEnterTime;}
			set{this.tEnterTime = value;}
		}

		public byte[] ImageData
		{
			get { return this.imageData; }
			set { this.imageData = value; }
		}
	}
}
