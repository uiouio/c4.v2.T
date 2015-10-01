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

using CPTT.DataAccess;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// GradesDataAccess 的摘要说明。
	/// </summary>
	public class GradesDataAccess : IDisposable
	{
		private Database db = null;
		public GradesDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetGradeInfoList(int index)
		{
			DataSet gradeInfoList;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGrade_InfoList");
				dbCommandWrapper.AddInParameter("@type",DbType.Int32,index);

				gradeInfoList = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return gradeInfoList;
		}

		public DataSet GetGradeInfo(int gradeID)
		{
			DataSet gradeInfo;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,gradeID);

				gradeInfo = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return gradeInfo;
		}

		public DataSet GetGradeNumber()
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("gar_getgradenumber");
				return db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public DataSet GetClassNumber(string gradeName)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("gar_getclassnumber");
				dbCommandWrapper.AddInParameter("@gradeName",DbType.String,gradeName);
				return db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int InsertGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeName",DbType.String,grade.GradeName);
				dbCommandWrapper.AddInParameter("@info_gradeRemark",DbType.String,grade.GradeRemark);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,grade.GradeID);
				dbCommandWrapper.AddInParameter("@gradeType",DbType.String,grade.GradeType);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rowsAffected;
		}

		public int UpdateGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,grade.GradeID);
				dbCommandWrapper.AddInParameter("@info_gradeName",DbType.String,grade.GradeName);
				dbCommandWrapper.AddInParameter("@info_gradeRemark",DbType.String,grade.GradeRemark);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteGradeInfo(int gradeID)
		{
			int rowsAffected = 0;
			
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("DeleteGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,gradeID);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);

				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public DataSet GetGradeNumber(string getGradeName,string getGradeNumber)
		{
			DataSet dsGradeNumber;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGradeList");
				dbCommandWrapper.AddInParameter("@GradeName",DbType.String,getGradeName);
				dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,getGradeNumber);
				dsGradeNumber = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dsGradeNumber;
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

			if (db != null)
			{
				db = null;
			}
		}  

		#endregion
	}
}
