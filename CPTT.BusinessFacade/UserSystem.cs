//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// UserSystem ��ժҪ˵����
	/// </summary>
	public class UserSystem
	{
		public UserSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public int userLogin(User user)
		{
			return new UserRule().userLogin(user);
		}

		public void CreateUserAccount(string userAccount,string userPwd)
		{
			new UsersDataAccess().CreateUserAccount(userAccount,userPwd);
		}

		public void DeleteUserAccount(string userAccount)
		{
			new UsersDataAccess().DeleteUserAccount(userAccount);
		}

		public int ChangePwd(string oldPwd,string newPwd)
		{
			return new UsersDataAccess().ChangePwd(oldPwd,newPwd);
		}

		public void AddUserRole(string userAccount,string userRole)
		{
			new UsersDataAccess().AddUserRole(userAccount,userRole);
		}

		public int UpdateUserRole(string userAccount,string newUserRole)
		{
			return new UsersDataAccess().UpdateUserRole(userAccount,newUserRole);
		}

		public string GetUserRole(string userAccount)
		{
			return new UsersDataAccess().GetUserRole(userAccount);
		}

		public void DeleteUserRole(string userAccount,string userRole)
		{
			new UsersDataAccess().DeleteUserRole(userAccount,userRole);
		}

		public void DeleteSpecialRole()
		{
			using(UsersDataAccess usersDataAccess = new UsersDataAccess())
			{
				usersDataAccess.DeleteSpecialRole();
			}
		}
	}
}
