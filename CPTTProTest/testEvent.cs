using System;

namespace CPTTProTest
{
	/// <summary>
	/// testEvent ��ժҪ˵����
	/// </summary>
	public class testEvent
	{
		public delegate void SendCardSuccessedHandler();

		public event SendCardSuccessedHandler SendCardSuccessed;

		public testEvent()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
