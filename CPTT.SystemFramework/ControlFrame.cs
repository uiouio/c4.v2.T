//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// ControlFrame 的摘要说明。
	/// </summary>
	public struct ControlFrame
	{
		public byte[] sym;//特征字节,固定为'**'
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
