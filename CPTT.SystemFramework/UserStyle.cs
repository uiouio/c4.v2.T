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
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class UserStyle
	{
		private string styleName;
		private string skinName;

		public UserStyle()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public string StyleName
		{
			get{return this.styleName;}
			set{this.styleName = value;}
		}

		public string SkinName
		{
			get{return this.skinName;}
			set{this.skinName = value;}
		}
	}
}
