//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;
namespace CPTT.SystemFramework
{
	/// <summary>
	/// Classes ��ժҪ˵����
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
			// TODO: �ڴ˴���ӹ��캯���߼�
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
