using System;
using System.Collections.Generic;
using System.Linq;
using Task1CS.Classes;
using Xunit;

namespace Task1CS.Test.Classes
{
	public class TestCircle
	{
		[Theory]
		[MemberData(nameof(CircleData.CalcRadiusData), MemberType = typeof(CircleData))]
		public void TestCalcRadius( Circle circle, double expected)
		{
			var actual = circle.CalcRadius();
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[MemberData(nameof(CircleData.ParseData), MemberType = typeof(CircleData))]
		public void TestParse( string line, bool expected)
		{
			var circle = new Circle();
			var actual = circle.Parse(line);
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[MemberData(nameof(CircleData.CalcSquareData), MemberType = typeof(CircleData))]
		public void TestCalcSquare( Circle circle, double expected)
		{
			var actual = circle.CalcSquare();
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[MemberData(nameof(CircleData.CalcPerimeterData), MemberType = typeof(CircleData))]
		public void TestCalcPerimeter( Circle circle, double expected)
		{
			var actual = circle.CalcPerimeter();
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[MemberData(nameof(CircleData.GetPointsData), MemberType = typeof(CircleData))]
		public void TestGetPoints( Circle circle, Point[] expected)
		{
			var actual = circle.GetPoints();
			var enumerable = actual as Point[] ?? actual.ToArray();
			Assert.Equal(expected[0].X, enumerable[0].X);
			Assert.Equal(expected[0].Y, enumerable[0].Y);
			Assert.Equal(expected[1].X, enumerable[1].X);
			Assert.Equal(expected[1].Y, enumerable[1].Y);
		}
		
		[Theory]
		[MemberData(nameof(CircleData.ToStringData), MemberType = typeof(CircleData))]
		public void TestToString( Circle circle, string expected)
		{
			var actual = circle.ToString();
			Assert.Equal(expected, actual);
		}
		
		
		
		private class CircleData
		{
			public static IEnumerable<object[]> CalcRadiusData => new List<object[]>
			{
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(0, 1)
					}),
					1
				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(1, 1)
					}),
					Math.Sqrt(2)
				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(4, 4)
					}),
					Math.Sqrt(32)
				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(5, 0)
					}),
					5
				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(1, 0), new Point(0, 1)
					}),
					Math.Sqrt(2)
				},
			};

			public static IEnumerable<object[]> ParseData => new List<object[]>
			{
				new object[]
				{
					"Circle{0 0 1 1}", true	
				},
				
				new object[]
				{
				"Circle {0 0 1 1}", false	
				},
				
				new object[]
				{
					"Circle { 0 0 1 1}", false	
				},
				
				new object[]
				{
					"Circle{ 0 0 1 1}", true	
				},
				
				new object[]
				{
					"Circle{0 0 1 1 }", true	
				},
				
				new object[]
				{
				"Triangle{5 0 0 1 1 5}", false	
				},
				new object[]
				{
					"0, 0, 1, 1", false	
				},
				new object[]
				{
					"", false	
				},
				new object[]
				{
					"Circle{0, 0, 1, 0}", false	
				},
				new object[]
				{
					"Circle{0 0 0 0}", false	
				},
			};

			public static IEnumerable<object[]> CalcSquareData => new List<object[]>
			{
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 1) 
					}), Math.PI
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 4) 
					}), Math.PI*16
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 10) 
					}), Math.PI*100
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 5) 
					}), Math.PI*25
				}
			};

			public static IEnumerable<object[]> CalcPerimeterData => new List<object[]>
			{
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 1) 
					}), Math.PI*2
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 4) 
					}), Math.PI*8
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 10) 
					}), Math.PI*20
				},
				
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 5) 
					}), Math.PI*10
				}
			};

			public static IEnumerable<object[]> GetPointsData => new List<object[]>
			{
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 1)
					}),
					new []
					{
						new Point(0, 0),
						new Point(0, 1)
					}				
				},

				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 4)
					}),
					new []
					{
						new Point(0, 0),
						new Point(0, 4)
					}				
				},

				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 10)
					}),
					new []
					{
						new Point(0, 0),
						new Point(0, 10)
					}				
				},

				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0),
						new Point(0, 5)
					}),
					new []
					{
						new Point(0, 0),
						new Point(0, 5)
					}
				}
			};

			public static IEnumerable<object[]> ToStringData => new List<object[]>
			{
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(0, 1)
					}),
					$"Circle:\n  Radius: 1\n  Points:\n    Point 0: x=0, y=0\n    Point 1: x=0, y=1"
				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(1, 1)
					}),
						$"Circle:\n  Radius: {Math.Sqrt(2)}\n  Points:\n    Point 0: x=0, y=0\n    Point 1: x=1, y=1"

				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(4, 4)
					}),
					
						$"Circle:\n  Radius: {Math.Sqrt(32)}\n  Points:\n    Point 0: x=0, y=0\n    Point 1: x=4, y=4"

				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(0, 0), new Point(5, 0)
					}),
					$"Circle:\n  Radius: 5\n  Points:\n    Point 0: x=0, y=0\n    Point 1: x=5, y=0"

				},
				new object[]
				{
					new Circle(new[]
					{
						new Point(1, 0), new Point(0, 1)
					}),
					$"Circle:\n  Radius: {Math.Sqrt(2)}\n  Points:\n    Point 0: x=1, y=0\n    Point 1: x=0, y=1"

				},

			};

		}
		
	}
}