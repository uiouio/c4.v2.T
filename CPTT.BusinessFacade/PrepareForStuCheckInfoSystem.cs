using System;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// PrepareForStuCheckInfoSystem 的摘要说明。
	/// </summary>
	public class PrepareForStuCheckInfoSystem
	{
		private bool isToDoPreapring = true;
		public PrepareForStuCheckInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private void CheckDate()
		{
			if(DateTime.Now.Month == 10)
			{
				if (DateTime.Now.Day <= 3)
				{
					isToDoPreapring = false;
				}
			}

			if ((DateTime.Now.Month == 1 || DateTime.Now.Month == 5) && DateTime.Now.Day == 1 )
				isToDoPreapring = false;

			if ( DateTime.Now.DayOfWeek.ToString().Equals("Saturday") || DateTime.Now.DayOfWeek.ToString().Equals("Sunday") )
				isToDoPreapring = false;

		}

		public void DoPreparingCheckInfo()
		{
			using ( PrepareForStuCheckInfoDataAccess prepareForStuCheckInfoDataAccess = new PrepareForStuCheckInfoDataAccess() )
			{
				CheckDate();

				try
				{
					if ( isToDoPreapring )
					{
						prepareForStuCheckInfoDataAccess.DoPrepareForCheck();

						
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		} 
	}
}
