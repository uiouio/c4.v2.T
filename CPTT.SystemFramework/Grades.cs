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
	/// Grade ��ժҪ˵����
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
			// TODO: �ڴ˴���ӹ��캯���߼�
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
