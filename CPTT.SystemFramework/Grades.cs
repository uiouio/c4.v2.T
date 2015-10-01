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
	/// Grade 的摘要说明。
	/// </summary>
	public class Grade
	{
		private int gradeID;
		private string gradeName;
		private string gradeRemark;
		private string gradeType;

		public Grade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int GradeID
		{
			get{return this.gradeID;}
			set{this.gradeID = value;}
		}

		public string GradeName
		{
			get{return this.gradeName;}
			set{this.gradeName = value;}
		}

		public string GradeRemark
		{
			get{return this.gradeRemark;}
			set{this.gradeRemark = value;}
		}

		public string GradeType
		{
			get{return this.gradeType;}
			set{this.gradeType = value;}
		}
	}
}
