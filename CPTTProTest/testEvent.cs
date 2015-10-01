using System;

namespace CPTTProTest
{
	/// <summary>
	/// testEvent 的摘要说明。
	/// </summary>
	public class testEvent
	{
		public delegate void SendCardSuccessedHandler();

		public event SendCardSuccessedHandler SendCardSuccessed;

		public testEvent()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void testE()
		{
			if(SendCardSuccessed!=null)
			{
				SendCardSuccessed();
			}
		}
	}
}
