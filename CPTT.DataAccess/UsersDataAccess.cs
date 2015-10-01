//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Security;
using System.Security.Principal;
using System.Security.Cryptography;

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;

namespace CPTT.DataAccess
{
	/// <summary>
	/// UsersDataAccess 的摘要说明。
	/// </summary>
	public class UsersDataAccess : IDisposable
	{
		private UserRoleManager manager;
		private Database dbUser = DatabaseFactory.CreateDatabase();

		public UsersDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			manager = new UserRoleManager("CTPPDB",ConfigurationManager.GetCurrentContext());
		}

		public void CreateUserAccount(string userAccount,string userPwd)
		{
			try
			{
				manager.CreateUser(userAccount,
					SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(userPwd)));
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void DeleteUserAccount(string userAccount)
		{
			try
			{
				if(manager.UserExists(userAccount))
				{
					manager.DeleteUser(userAccount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int ChangePwd(string oldPwd,string newPwd)
		{
			try
			{
				byte[] realUserPwd = manager.GetPassword(Thread.CurrentPrincipal.Identity.Name);

				byte[] userPassword = new SHA1Managed().ComputeHash(
					ASCIIEncoding.ASCII.GetBytes(oldPwd));

				if(!Convert.ToBase64String(userPassword).Equals
					(Convert.ToBase64String(realUserPwd)))
				{
					return -1;
				}

				manager.ChangeUserPassword(Thread.CurrentPrincipal.Identity.Name,
					new SHA1Managed().ComputeHash(ASCIIEncoding.ASCII.GetBytes(newPwd)));

				return 0;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void AddUserRole(string userAccount,string userRole)
		{
			try
			{
				manager.CreateUserRole(userAccount,userRole);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

//		public void UpdateUserRole(string userAccount,string newUserRole)
//		{
//			try
//			{
//				string userOldRole = GetUserRole(userAccount);
//
//				if(userOldRole!=string.Empty)
//				{
//					manager.DeleteUserRole(userAccount,userOldRole);
//					manager.CreateUserRole(userAccount,newUserRole);
//				}
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//		}

		public int UpdateUserRole(string userAccount,string newUserRole)
		{
			int rtnValue = 0;
			try
			{
				DBCommandWrapper dbCommandWrapper = dbUser.GetStoredProcCommandWrapper("tea_update_user_roles");
				dbCommandWrapper.AddInParameter("@tid",DbType.String,userAccount);
				dbCommandWrapper.AddInParameter("@role",DbType.String,newUserRole);
				dbCommandWrapper.AddOutParameter("@rtnValue",DbType.Int32,4);
				dbUser.ExecuteNonQuery(dbCommandWrapper);
				rtnValue = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rtnValue"));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rtnValue;
		}

		public string GetUserRole(string userAccount)
		{
			try
			{
				DataSet userRoles = manager.GetUserRoles(userAccount);
				
				if(userRoles.Tables[0].Rows.Count>0)
				{
					return userRoles.Tables[0].Rows[0]["RoleName"].ToString();
				}
				else
				{
					return string.Empty;
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void DeleteUserRole(string userAccount,string userRole)
		{
			try
			{
				manager.DeleteUserRole(userAccount,userRole);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int userLogin(User user)
		{
			int loginState = 0;

			byte[] userPassword = new SHA1Managed().ComputeHash(
				ASCIIEncoding.ASCII.GetBytes(user.UserPassword));

			//			manager.CreateUser(user.UserLoginID,userPassword);

			try
			{
				//				if(manager.UserExists(user.UserLoginID))
				//				{
				//					if(Convert.ToBase64String(userPassword).Equals
				//						(Convert.ToBase64String(manager.GetPassword(user.UserLoginID))))
				//					{
				NamePasswordCredential credentials;
				credentials = new NamePasswordCredential(user.UserLoginID,
					ASCIIEncoding.ASCII.GetBytes(user.UserPassword));

				IAuthenticationProvider authProvider;
				authProvider = AuthenticationFactory.GetAuthenticationProvider("Database Provider");

				bool authenticated = false;

				IIdentity identity;
				authenticated = authProvider.Authenticate(credentials,out identity);

				if(authenticated)
				{

					loginState = 1;//登陆成功

					IRolesProvider rolesProvider = RolesFactory.GetRolesProvider("Role Database Provider");

					IPrincipal principal = rolesProvider.GetRoles(identity);

					Thread.CurrentPrincipal = principal;
				}
				//					}
				//					else
				//					{
				//						loginState = 2;//密码错误
				//					}
				//				}
				//				else
				//				{
				//					loginState = -1;//用户不存在
				//				}
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return loginState;
		}

		public bool userAuthorized(string rule)
		{
			bool authorized = false;

			IAuthorizationProvider authorProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider");

			authorized = authorProvider.Authorize(Thread.CurrentPrincipal,rule);

			return authorized;
		}

		public void DeleteSpecialRole()
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = dbUser.GetStoredProcCommandWrapper("DeleteSpecialRoles");
				dbUser.ExecuteNonQuery(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); 
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 

			if (manager != null)
			{
				manager = null;
			}
		}

		#endregion
	}
}
