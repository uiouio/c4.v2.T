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
	/// User ��ժҪ˵����
	/// </summary>
	public class User
	{
		private string userLoginID; 
		private string userPassword;

		public User()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public User(string userLoginID,string userPassword)
		{
			this.userLoginID = userLoginID;
			this.userPassword = userPassword;
		}

		public string UserLoginID
		{
			get{return this.userLoginID;}
			set{userLoginID = value;}
		}

		public string UserPassword
		{
			get{return this.userPassword;}
			set{userPassword = value;}
		}
	}
}
