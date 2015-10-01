using System;
using System.Data;
using System.Collections;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StudentCheckInfo 的摘要说明。
	/// </summary>
	public class StudentCheckInfo
	{
		private ArrayList cellManualModify = new ArrayList();
		private ArrayList cellManualInput = new ArrayList();
		private ArrayList customManualModify = new ArrayList();
		private ArrayList customManualInput = new ArrayList();
		public StudentCheckInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public DataSet GetStuMorningCheckInfo(string getGrade,string getClass,string getName,string getNumber,
			string getBegDate,string getEndDate,string getState)
		{
			using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
			{
				try
				{
					this.ClearCellManualModify();
					this.ClearCellManualInput();
					DataSet dsMorningCheckInfo = stuCheckInfoDataAccess.GetMorningCheckInfo(getGrade,getClass,getName,
						getNumber,getBegDate,getEndDate,getState);
					for ( int modifyRow = 0;modifyRow < dsMorningCheckInfo.Tables[0].Rows.Count; modifyRow ++)
					{
						// 添加需要对修改作出标识的行号
						if ( Convert.ToInt32(dsMorningCheckInfo.Tables[0].Rows[modifyRow][5]) == 1 || 
							Convert.ToInt32(dsMorningCheckInfo.Tables[0].Rows[modifyRow][5]) == 3)
						{
							// 手工修改
//							this.SetCellManualModify(modifyRow);
							this.SetCellManualModify(dsMorningCheckInfo.Tables[0].Rows[modifyRow][1].ToString());
							this.SetCellManualModify(dsMorningCheckInfo.Tables[0].Rows[modifyRow][3].ToString());
						}

						if ( Convert.ToInt32(dsMorningCheckInfo.Tables[0].Rows[modifyRow][5]) == 2 ||
							Convert.ToInt32(dsMorningCheckInfo.Tables[0].Rows[modifyRow][5]) == 4)
						{	
							// 手动输入
//							this.SetCellManualInput(modifyRow);
							this.SetCellManualInput(dsMorningCheckInfo.Tables[0].Rows[modifyRow][1].ToString());
							this.SetCellManualInput(dsMorningCheckInfo.Tables[0].Rows[modifyRow][3].ToString());
						}
					}
					return dsMorningCheckInfo;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetStuBackHomeCheckInfo(string getGrade,string getClass,string getName,string getNumber,
			string getBegDate,string getEndDate,string getState)
		{
			using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
			{
				try
				{
					return stuCheckInfoDataAccess.GetBackHomeCheckInfo(getGrade,getClass,getName,getNumber,
						getBegDate,getEndDate,getState);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetStuStatusList()
		{
			try
			{
				using (StudentAttendCalcDataAccess stuAttendCalcDataAccess = new StudentAttendCalcDataAccess())
				{
					return stuAttendCalcDataAccess.DoGetStatusList();
				}
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataSet GetStuCustomStatusList()
		{
			try
			{
				using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
				{
					return stuCheckInfoDataAccess.GetCustomStatusList();
				}
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataSet GetStuCustomCheckInfo(string getGrade,string getClass,string getName,string getNumber,
			string getBegDate,string getEndDate,string getState)
		{
			using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
			{
				try
				{
					this.ClearCustomManualModify();
					this.ClearCustomManualInput();
					DataSet dsCustomCheckInfo = stuCheckInfoDataAccess.GetCustomCheckInfo(getGrade,getClass,getName,
						getNumber,getBegDate,getEndDate,getState);
					for ( int modifyRow = 0; modifyRow < dsCustomCheckInfo.Tables[0].Rows.Count; modifyRow ++ )
					{
						if ( Convert.ToInt32(dsCustomCheckInfo.Tables[0].Rows[modifyRow][5]) == 3 )
						{
//							this.SetCustomManualModify(modifyRow);
							this.SetCustomManualModify(dsCustomCheckInfo.Tables[0].Rows[modifyRow][1].ToString());
							this.SetCustomManualModify(dsCustomCheckInfo.Tables[0].Rows[modifyRow][3].ToString());
						}

						if ( Convert.ToInt32(dsCustomCheckInfo.Tables[0].Rows[modifyRow][5]) == 4 )
						{
//							this.SetCustomManualInput(modifyRow);
							this.SetCustomManualInput(dsCustomCheckInfo.Tables[0].Rows[modifyRow][1].ToString());
							this.SetCustomManualInput(dsCustomCheckInfo.Tables[0].Rows[modifyRow][3].ToString());
						}
					}
					return dsCustomCheckInfo;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void UpdateState(string getNumber,string getEnterDate,string getState,string getCurRecTime,string getOrigState)
		{
			using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
			{
				try
				{
					stuCheckInfoDataAccess.DoUpdateState(getNumber,getEnterDate,getState,getCurRecTime,getOrigState);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public DataSet GetClassName(string getName,string getNumber)
		{
			using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
			{
				try
				{
					return stuCheckInfoDataAccess.GetClassName(getName,getNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}
		
		private void SetCellManualModify ( string cellInfo )
		{
			this.cellManualModify.Add(cellInfo);
		}

		private void SetCellManualInput ( string cellInfo )
		{
			this.cellManualInput.Add(cellInfo);
		}

		public ArrayList GetCellManualModify()
		{
			return this.cellManualModify;
		}

		public ArrayList GetCellManualInput()
		{
			return this.cellManualInput;
		}

		private void ClearCellManualModify()
		{
			this.cellManualModify.Clear();
		}

		private void ClearCellManualInput()
		{
			this.cellManualInput.Clear();
		}

		private void SetCustomManualModify( string cellInfo )
		{
			this.customManualModify.Add(cellInfo);
		}

		private void SetCustomManualInput( string cellInfo )
		{
			this.customManualInput.Add(cellInfo);
		}

		public ArrayList GetCustomManualModify()
		{
			return this.customManualModify;
		}

		public ArrayList GetCustomManualInput()
		{
			return this.customManualInput;
		}

		private void ClearCustomManualModify()
		{
			this.customManualModify.Clear();
		}

		private void ClearCustomManualInput()
		{
			this.customManualInput.Clear();
		}

	}
}
