//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// UserRule ��ժҪ˵����
	/// </summary>
	public class UserRule
	{
		public UserRule()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public int userLogin(User user)
		{
			int loginState = 0;

			using(UsersDataAccess usersDataAccess = new UsersDataAccess())
			{
				loginState = usersDataAccess.userLogin(user);
			}

			return loginState;
		}
	}
}
