using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Point
	{
		//double x;
		//double y;
		
		/// ////	Properties	//////////////////////////////////////

		/*
		 public double X
		{
			get
			{
				return x;
			}
			set
			{
				if (value > 100) value = 100;
				x = value;
			}
		}
		public double Y
		{
			get
			{
				return y;
			}
			set
			{
				if (value > 100) value = 100;
				y = value;
			}
		}
		*/

		public double X { get;set; } // Auto properties
		public double Y { get;set; } // Auto properties

		/// ////	EndProperties	//////////////////////////////////////

		/*
		public double GetX() {
			return x; 
		}
		public double GetY() {
			return y; 
		}

		public void SetX(double x)
		{
			this.x = x;
		}
		public void SetY(double y)
		{
			this.y = y;
		}
		*/

		public Point(double x = 0, double y = 0) 
		{  
			X = x;
			Y = y;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		~Point()
		{
			Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
		}

		public Point(Point other)
		{
			X = other.X;
			Y = other.Y;
			Console.WriteLine($"CopyConstructor:\t{this.GetHashCode()}");
		}

		// Operators:

		public static Point operator+(Point left, Point right)
		{
			return new Point
				(
				left.X + right.X,
				left.Y + right.Y
				);
		}

		public void Info()
		{
			//Console.WriteLine($"X = {GetX()}, Y = {GetY()}");
			Console.WriteLine($"X = {X}, Y = {Y}");
		}
	
	}
}


