//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// DataFrame ��ժҪ˵����
	/// </summary>
	public struct DataFrame
	{
		public byte[] sym;//�����ֽ�,�̶�Ϊ'@@'
		public byte desAddr;
		public byte comFrameLen;
		public byte srcAddr;
		public byte protocol;
		public byte seq;
		public byte[] frameData;
		public byte checkSum;

		public byte computeCheckSum()
		{
			this.checkSum = (byte)(this.sym[0] + this.sym[1] + 
				this.desAddr + this.comFrameLen + this.srcAddr + 
				this.protocol + this.seq);

			for(int i=0;i<this.frameData.Length;i++)
			{
				this.checkSum += (byte)this.frameData[i];
			}

			return checkSum;
		}

		public byte[] frameToBytes()
		{
			byte[] byteToSend = new byte[this.comFrameLen];

			byteToSend[0] = this.sym[0];
			byteToSend[1] = this.sym[1];
			byteToSend[2] = this.desAddr;
			byteToSend[3] = this.comFrameLen;
			byteToSend[4] = this.srcAddr;
			byteToSend[5] = this.protocol;
			byteToSend[6] = this.seq;

			for(int i = 0;i<this.frameData.Length;i++)
			{
				byteToSend[7+i] = frameData[i];
			}

			byteToSend[comFrameLen-1] = this.checkSum;

			return byteToSend;
		}
		
		public static DataFrame convertToFrame(byte[] receiveBytes)
		{
			DataFrame dataFrame = new DataFrame();

			dataFrame.sym = new byte[2];
			dataFrame.sym[0] = receiveBytes[0];
			dataFrame.sym[1] = receiveBytes[1];
			dataFrame.desAddr = receiveBytes[2];
			dataFrame.comFrameLen = receiveBytes[3];
			dataFrame.srcAddr = receiveBytes[4];
			dataFrame.protocol = receiveBytes[5];
			dataFrame.seq = receiveBytes[6];

			int dataFrameLength = receiveBytes.Length - 8;
			dataFrame.frameData = new byte[dataFrameLength];

			for(int i = 0;i<dataFrameLength;i++)
			{
				dataFrame.frameData[i] = receiveBytes[7+i];
			}

			dataFrame.checkSum = receiveBytes[receiveBytes.Length - 1];

			return dataFrame;
		}
	}
}
