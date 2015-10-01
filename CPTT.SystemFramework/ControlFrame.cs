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
	/// ControlFrame ��ժҪ˵����
	/// </summary>
	public struct ControlFrame
	{
		public byte[] sym;//�����ֽ�,�̶�Ϊ'**'
		public byte desAddr;
		public byte srcAddr;
		public byte response;
		public byte seq;
		public byte checkSum;

		public byte computeCheckSum()
		{
			this.checkSum = (byte)(this.sym[0] + this.sym[1] + 
				this.desAddr + this.srcAddr + this.response + 
				this.seq);

			return checkSum;
		}

		public byte[] convertToBytes()
		{
			return new byte[]{this.sym[0],this.sym[1],this.desAddr,
			this.srcAddr,this.response,this.seq,this.checkSum};
		}

		public static ControlFrame convertToFrame(byte[] receivedBytes)
		{
			ControlFrame receivedControlFrame = new ControlFrame();
			if(receivedBytes.Length == 7)
			{
				receivedControlFrame.sym = new byte[]{receivedBytes[0],receivedBytes[1]};
				receivedControlFrame.desAddr = receivedBytes[2];
				receivedControlFrame.srcAddr = receivedBytes[3];
				receivedControlFrame.response = receivedBytes[4];
				receivedControlFrame.seq = receivedBytes[5];
				receivedControlFrame.checkSum = receivedBytes[6];
			}

			return receivedControlFrame;
		}
	}
}
