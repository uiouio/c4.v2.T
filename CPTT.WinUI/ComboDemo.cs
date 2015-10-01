using System;
using System.Drawing;
using System.Collections;

using ZedGraph;

namespace CPTT.WinUI
{
	/// <summary>
	/// ComboDemo ��ժҪ˵����
	/// </summary>
		public class ComboDemo : DemoBase
		{

			public ComboDemo() : base( "A demo that combines bar charts with line graphs, curve filling, text items, etc.",
				"Combo Demo", DemoType.General, DemoType.Line )
			{
				GraphPane myPane = base.GraphPane;

				// Set the titles and axis labels
				myPane.Title = "Wacky Widget Company\nProduction Report";
				myPane.XAxis.Title = "Time, Days\n(Since Plant Construction Startup)";
				myPane.YAxis.Title = "Widget Production\n(units/hour)";
			
				LineItem curve;

				// Set up curve "Larry"
				double[] x = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
				double[] y = { 20, 10, 50, 25, 35, 75, 90, 40, 33, 50 };
				// Use green, with circle symbols
				curve = myPane.AddCurve( "Larry", x, y, Color.Green, SymbolType.Circle );
				curve.Line.Width = 1.5F;
				// Fill the area under the curve with a white-green gradient
				curve.Line.Fill = new Fill( Color.White, Color.FromArgb( 60, 190, 50), 90F );
				// Make it a smooth line
				curve.Line.IsSmooth = true;
				curve.Line.SmoothTension = 0.6F;
				// Fill the symbols with white
				curve.Symbol.Fill = new Fill( Color.White );
				curve.Symbol.Size = 10;
			
				// Second curve is "moe"
				double[] x3 = { 150, 250, 400, 520, 780, 940 };
				double[] y3 = { 5.2, 49.0, 33.8, 88.57, 99.9, 36.8 };
				// Use a red color with triangle symbols
				curve = myPane.AddCurve( "Moe", x3, y3, Color.FromArgb( 200, 55, 135), SymbolType.Triangle );
				curve.Line.Width = 1.5F;
				// Fill the area under the curve with semi-transparent pink using the alpha value
				curve.Line.Fill = new Fill( Color.White, Color.FromArgb( 160, 230, 145, 205), 90F );
				// Fill the symbols with white
				curve.Symbol.Fill = new Fill( Color.White );
				curve.Symbol.Size = 10;
			
				// Third Curve is a bar, called "Wheezy"
				double[] x4 = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
				double[] y4 = { 30, 45, 53, 60, 75, 83, 84, 79, 71, 57 };
				BarItem bar = myPane.AddBar( "Wheezy", x4, y4, Color.SteelBlue );
				// Fill the bars with a RosyBrown-White-RosyBrown gradient
				bar.Bar.Fill = new Fill( Color.RosyBrown, Color.White, Color.RosyBrown );

				// Fourth curve is a bar
				double[] x2 = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
				double[] y2 = { 10, 15, 17, 20, 25, 27, 29, 26, 24, 18 };
				bar = myPane.AddBar( "Curly", x2, y2, Color.RoyalBlue );
				// Fill the bars with a RoyalBlue-White-RoyalBlue gradient
				bar.Bar.Fill = new Fill( Color.RoyalBlue, Color.White, Color.RoyalBlue );
			
				// Fill the pane background with a gradient
				myPane.PaneFill = new Fill( Color.WhiteSmoke, Color.Lavender, 0F );
				// Fill the axis background with a gradient
				myPane.AxisFill = new Fill( Color.FromArgb( 255, 255, 245),
					Color.FromArgb( 255, 255, 190), 90F );
			

				// Make each cluster 100 user scale units wide.  This is needed because the X Axis
				// type is Linear rather than Text or Ordinal
				myPane.ClusterScaleWidth = 100;
				// Bars are stacked
				myPane.BarType = BarType.Stack;

				// Enable the X and Y axis grids
				myPane.XAxis.IsShowGrid = true;
				myPane.YAxis.IsShowGrid = true;

				// Manually set the scale maximums according to user preference
				myPane.XAxis.Max = 1200;
				myPane.YAxis.Max = 120;
			
				// Add a text item to decorate the graph
				TextItem text = new TextItem("First Prod\n21-Oct-93", 175F, 80.0F );
				// Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
				text.Location.AlignH = AlignH.Center;
				text.Location.AlignV = AlignV.Bottom;
				text.FontSpec.Fill = new Fill( Color.White, Color.PowderBlue, 45F );
				text.FontSpec.StringAlignment = StringAlignment.Near;
				myPane.GraphItemList.Add( text );

				// Add an arrow pointer for the above text item
				ArrowItem arrow = new ArrowItem( Color.Black, 12F, 175F, 77F, 100F, 45F );
				arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
				myPane.GraphItemList.Add( arrow );

				// Add a another text item to to point out a graph feature
				text = new TextItem("Upgrade", 700F, 50.0F );
				// rotate the text 90 degrees
				text.FontSpec.Angle = 90;
				// Align the text such that the Right-Center is at (700, 50) in user scale coordinates
				text.Location.AlignH = AlignH.Right;
				text.Location.AlignV = AlignV.Center;
				// Disable the border and background fill options for the text
				text.FontSpec.Fill.IsVisible = false;
				text.FontSpec.Border.IsVisible = false;
				myPane.GraphItemList.Add( text );

				// Add an arrow pointer for the above text item
				arrow = new ArrowItem( Color.Black, 15, 700, 53, 700, 80 );
				arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
				arrow.PenWidth = 2.0F;
				myPane.GraphItemList.Add( arrow );

				// Add a text "Confidential" stamp to the graph
				text = new TextItem("Confidential", 0.85F, -0.03F );
				// use AxisFraction coordinates so the text is placed relative to the AxisRect
				text.Location.CoordinateFrame = CoordType.AxisFraction;
				// rotate the text 15 degrees
				text.FontSpec.Angle = 15.0F;
				// Text will be red, bold, and 16 point
				text.FontSpec.FontColor = Color.Red;
				text.FontSpec.IsBold = true;
				text.FontSpec.Size = 16;
				// Disable the border and background fill options for the text
				text.FontSpec.Border.IsVisible = false;
				text.FontSpec.Fill.IsVisible = false;
				// Align the text such the the Left-Bottom corner is at the specified coordinates
				text.Location.AlignH = AlignH.Left;
				text.Location.AlignV = AlignV.Bottom;
				myPane.GraphItemList.Add( text );

				// Add a BoxItem to show a colored band behind the graph data
				BoxItem box = new BoxItem( new RectangleF( 0, 110, 1200, 10 ),
					Color.Empty, Color.FromArgb( 225, 245, 225) );
				box.Location.CoordinateFrame = CoordType.AxisXYScale;
				// Align the left-top of the box to (0, 110)
				box.Location.AlignH = AlignH.Left;
				box.Location.AlignV = AlignV.Top;
				// place the box behind the axis items, so the grid is drawn on top of it
				box.ZOrder = ZOrder.E_BehindAxis;
				myPane.GraphItemList.Add( box );
			
				// Add some text inside the above box to indicate "Peak Range"
				TextItem myText = new TextItem( "Peak Range", 1170, 105 );
				myText.Location.CoordinateFrame = CoordType.AxisXYScale;
				myText.Location.AlignH = AlignH.Right;
				myText.Location.AlignV = AlignV.Center;
				myText.FontSpec.IsItalic = true;
				myText.FontSpec.IsBold = false;
				myText.FontSpec.Fill.IsVisible = false;
				myText.FontSpec.Border.IsVisible = false;
				myPane.GraphItemList.Add( myText );
			
				base.ZedGraphControl.AxisChange();
			}
		}
	}
