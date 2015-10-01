//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// UserSystem 的摘要说明。
	/// </summary>
	public class UserSystem
	{
		public UserSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
