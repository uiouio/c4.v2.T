using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// Machine ��ժҪ˵����
	/// </summary>
	public class Machine
	{
		private Int16 address;
		private Int16 type;
		private Int16 volume;

		public Machine()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public Int16 Address
		{
			get{return this.address;}
			set{this.address = value;}
		}

		public Int16 Type
		{
			get{return this.type;}
			set{this.type = value;}
		}

		public Int16 Volume
		{
			get{return this.volume;}
			set{this.volume = value;}
		}
	}
}
