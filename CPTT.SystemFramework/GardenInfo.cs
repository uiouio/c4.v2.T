using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// GardenInfo ��ժҪ˵����
	/// </summary>
	public class GardenInfo
	{
		private string gardenID;
		private string gardenName;
		private string gardenRegCode;
		private string gardenAddr;
		private string gardenContact;
		private string gardenFeature;
		private byte[] gardenImage;

		public GardenInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public string GardenID
		{
			get{return this.gardenID;}
			set{this.gardenID = value;}
		}

		public string GardenName
		{
			get{return this.gardenName;}
			set{this.gardenName = value;}
		}

		public string GardenRegCode
		{
			get{return this.gardenRegCode;}
			set{this.gardenRegCode = value;}
		}

		public string GardenAddr
		{
			get{return this.gardenAddr;}
			set{this.gardenAddr = value;}
		}

		public string GardenContact
		{
			get{return this.gardenContact;}
			set{this.gardenContact = value;}
		}

		public string GardenFeature
		{
			get{return this.gardenFeature;}
			set{this.gardenFeature = value;}
		}

		public byte[] GardenImage
		{
			get{return this.gardenImage;}
			set{this.gardenImage = value;}
		}
	}
}
