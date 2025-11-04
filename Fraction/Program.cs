//#define CONSTRUCTORS_CHECK
#define ARITHMETICAL_CHECK
//#define COMPARISON_OPERATORS


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Program
	{
		static readonly string delimiter = "\n--------------------------------\n";
		static void Main(string[] args)
		{
#if CONSTRUCTORS_CHECK
			Fraction A = new Fraction();
			A.Info();
			Fraction B = new Fraction(5);
			B.Info();
			Fraction C = new Fraction(2, 5);
			C.Info();
			Fraction D = new Fraction(3, 2, 5);
			D.Info();
			Fraction E = new Fraction(D);
			E.Info();
#endif

#if ARITHMETICAL_CHECK
			Fraction A = new Fraction(2, 3, 4);
			A.Info();
			A.To_improper().Info();
			A.To_improper(A.Integer, A.Numerator, A.Denominator).Info();
			Console.WriteLine(delimiter);

			Fraction B = new Fraction(3, 4, 5);
			B.Info();
			B.To_improper(B.Integer, B.Numerator, B.Denominator).Info();
			Console.WriteLine(delimiter);

			Fraction C = new Fraction(A);
			C.Info();
			C = A + B;
			C.Info();
			C.To_proper(C.Integer, C.Numerator, C.Denominator).Info();
			Console.WriteLine(delimiter);

			Fraction E = new Fraction(B - A);
			E.Info();
			E += A;
			E.Info();
			E.Reduce().Info();
			E.To_proper(E.Integer, E.Numerator, E.Denominator).Info();
			E.Inverted().Info();
			E.Inverted(E.Integer, E.Numerator, E.Denominator).Info();
			Console.WriteLine(delimiter);

			E *= A;
			E.Info();
			E /= A;
			E.Info();
			Console.WriteLine(delimiter);

			A.To_proper(A.Integer, A.Numerator, A.Denominator).Info();
			Fraction D = new Fraction(A);
			D.Info();
			D++;
			D.Info();
			D--;
			D.Info();
#endif

#if COMPARISON_OPERATORS
			Fraction A = new Fraction(2, 3, 4);
			A.Info();
			Fraction B = new Fraction(3, 4, 5);
			B.Info();
			Console.WriteLine(delimiter);

			Console.WriteLine(A < B);
			Console.WriteLine(A == B);
			Console.WriteLine(A != B);
			Console.WriteLine(A > B); 
#endif

		}
	}
}
