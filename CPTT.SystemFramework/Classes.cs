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
	/// Classes 的摘要说明。
	/// </summary>
	public class Classes
	{
		private int infoClassNumber;
		private string infoClassName;
		private int classInfoGradeNumber;
		private int infoMachineAddr;
		private string infoClassRemark;
		private string classType;
		public Classes()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InfoClassNumber
		{
			get{return this.infoClassNumber;}
			set{this.infoClassNumber = value;}
		}

		public string InfoClassName
		{
			get{return this.infoClassName;}
			set{this.infoClassName = value;}
		}

		public int ClassInfoGradeNumber
		{
			get{return this.classInfoGradeNumber;}
			set{this.classInfoGradeNumber = value;}
		}

		public int InfoMachineAddr
		{
			get{return this.infoMachineAddr;}
			set{this.infoMachineAddr = value;}
		}

		public string InfoClassRemark
		{
			get{return this.infoClassRemark;}
			set{this.infoClassRemark = value;}
		}

		public string ClassType
		{
			get{return this.classType;}
			set{this.classType = value;}
		}
	}
}
