using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		int integer; //целая часть
		int numerator; //числитель
		int denominator; //знаменатель

		public int Integer { get; set; }
		public int Numerator { get; set; }
		public int Denominator { get; set; }

		//	Constructors:

		public Fraction()
		{
			this.Integer = 0;
			this.Numerator = 0;
			this.Denominator = 1;
			Console.WriteLine($"DConstructor:\t{this.GetHashCode()}");
		}
		public Fraction(int integer)
		{
			this.Integer = integer;
			this.Numerator = 0;
			this.Denominator = 1;
			Console.WriteLine($"SConstructor:\t{this.GetHashCode()}");
		}
		public Fraction(int numerator, int denominator)
		{
			this.Integer = 0;
			this.Numerator = numerator;
			this.Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}

		public Fraction(int integer, int numerator, int denominator)
		{
			this.Integer = integer;
			this.Numerator = numerator;
			this.Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}

		public Fraction(Fraction other)
		{
			this.Integer = other.Integer;
			this.Numerator = other.Numerator;
			this.Denominator = other.Denominator;
			Console.WriteLine($"CopyConstructor:\t{this.GetHashCode()}");
		}

		~Fraction()
		{
			Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
		}

		// Operators:

		public static Fraction operator +(Fraction left, Fraction right)
		{
			left.To_improper(left.Integer, left.Numerator, left.Denominator);
			right.To_improper(right.Integer, right.Numerator, right.Denominator);
			return new Fraction
			(
				left.Numerator * right.Denominator + right.Numerator * left.Denominator,
				left.Denominator * right.Denominator
			);
		}
		public static Fraction operator -(Fraction left, Fraction right)
		{
			left.To_improper(left.Integer, left.Numerator, left.Denominator);
			right.To_improper(right.Integer, right.Numerator, right.Denominator);
			return new Fraction
			(
				left.Numerator * right.Denominator - right.Numerator * left.Denominator,
				left.Denominator * right.Denominator
			);
		}

		public static Fraction operator *(Fraction left, Fraction right)
		{
			left.To_improper(left.Integer, left.Numerator, left.Denominator);
			right.To_improper(right.Integer, right.Numerator, right.Denominator);

			return new Fraction
				(

				left.Numerator * right.Numerator,
				left.Denominator * right.Denominator
				).Reduce();
		}
		public static Fraction operator /(Fraction left, Fraction right)
		{
			left.To_improper(left.Integer, left.Numerator, left.Denominator);
			right.To_improper(right.Integer, right.Numerator, right.Denominator);

			return left*right.Inverted(right.Integer, right.Numerator, right.Denominator);
		}

		public static Fraction operator ++(Fraction obj)
		{
			obj = obj.To_proper(obj.Integer, obj.Numerator, obj.Denominator);
			obj.Integer++;
			return obj;
		}
		public static Fraction operator --(Fraction obj)
		{
			obj = obj.To_proper(obj.Integer, obj.Numerator, obj.Denominator);
			obj.Integer--;
			return obj;
		}

		public static bool operator ==(Fraction left, Fraction right)
		{
			return
				left.To_improper().Numerator * right.To_improper().Denominator == 
				right.To_improper().Numerator * left.To_improper().Denominator;
		}
		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		public static bool operator >(Fraction left, Fraction right)
		{
			return
				left.To_improper().Numerator * right.To_improper().Denominator > 
				right.To_improper().Numerator * left.To_improper().Denominator;
		}

		public static bool operator <(Fraction left, Fraction right)
		{
			return
				left.To_improper().Numerator * right.To_improper().Denominator <
				right.To_improper().Numerator * left.To_improper().Denominator;
		}



		// Methods:

		public Fraction To_improper()
		{
			Fraction copy = new Fraction(this);
			copy.Numerator += copy.Integer * copy.Denominator;
			copy.Integer = 0;
			return copy;
		}
		public Fraction To_improper(int integer, int numerator, int denominator)
		{
			this.Numerator += integer * denominator;
			this.Integer = 0;
			return this;
		}

		public Fraction To_proper()
		{
			Fraction copy = new Fraction(this);
			copy.Integer += copy.Numerator / copy.Denominator;
			copy.Numerator %= copy.Denominator;
			return copy;
		}
		public Fraction To_proper(int integer, int numerator, int denominator)
		{
			this.Integer += numerator / denominator;
			this.Numerator %= denominator;
			return this;
		}

		public Fraction Reduce()
		{
			int more, less, rest;
			if (Numerator > Denominator)
			{
				more = Numerator;
				less = Denominator;
			}
			else
			{
				less = Numerator;
				more = Denominator;
			}
			do
			{
				rest = more % less;
				more = less;
				less = rest;
			} while (rest > 0);
			int GCD = more;
			Numerator /= GCD;
			Denominator /= GCD;
			return this;
		}

		public Fraction Inverted()
		{
			Fraction inverted = new Fraction(this).To_improper();
			(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			return inverted;
		}
		public Fraction Inverted(int integer, int numerator, int denominator)
		{
			Fraction inverted = new Fraction(this).To_improper(this.Integer, this.Numerator, this.Denominator);
			(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			return inverted;
		}

		public void Info()
		{
			if (Denominator == 0)
			{
				Console.WriteLine("Error: The denominator must not be 0!");
				return;
			}
			if (Integer != 0)
			{
				Console.Write(Integer);
				if (Numerator != 0) Console.Write($"({Numerator}/{Denominator})\n");
				else Console.WriteLine("");
			}
			else
			{
				if (Numerator != 0) Console.Write($"{Numerator}/{Denominator}\n");
				else Console.WriteLine("");
			}
		}
	}
}
