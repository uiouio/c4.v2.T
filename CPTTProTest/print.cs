using System;
using System.Drawing;
using DevExpress.XtraPrinting;

namespace CPTTProTest
{
	/// <summary>
	/// print 的摘要说明。
	/// </summary>
	public class print : Link
	{
		internal int top = 0;
		internal Rectangle r = new Rectangle(0, 0, 150, 50);
		internal string caption = "Hello World!";
		
		public print(PrintingSystem ps) 
		{
			CreateDocument(ps);
		} 

		public override void CreateDocument(PrintingSystem ps) 
		{
			if(ps != null) 
			{
				BrickGraphics g = ps.Graph;
				g.BackColor = Color.White;
				g.BorderColor = Color.Black;
				g.Font = g.DefaultFont;
				g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near);

				base.CreateDocument(ps);
			}
		}

		protected override void CreateDetail(BrickGraphics graph) 
		{
			graph.DrawString(caption, Color.Black, r, BorderSide.None);
		}
	}
}
