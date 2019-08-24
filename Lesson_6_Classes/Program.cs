using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Lesson_6_Classes
{
	//public class FractionalNumber
	//{
	//	private int _numerator;
	//	private int _denominator;
	//	private double _result;

	//	public bool IsNegative => _numerator * _denominator < 0;

	//	public double ToDouble() => _numerator / _denominator;

	//	//public double Result(int numenator, int denominator)
	//	//{
	//	//	if (denominator != 0)
	//	//	{
	//	//		_result = numenator / denominator;
	//	//		return _result;
	//	//	}
	//	//	else
	//	//	{
	//	//		return 0;
	//	//	}
	//	//}

	//	public void Print() => Console.WriteLine($"{_numerator}/{_denominator}");

	//	//public void Add(int numenator)

	//	//public double Calc (double numenator, double denominator)
	//	//{
	//	//	double sum = numenator + denominator;
	//	//	double diff = numenator - denominator;
	//	//	double mult = numenator * denominator;
	//	//	if (denominator != 0)
	//	//	{
	//	//		_result = numenator / denominator;
	//	//		return _result;
	//	//	}
	//	//	else
	//	//	{
	//	//		return 0;
	//	//	}
	//}



	class Program
	{
		private int _first;
		private int _second;

		//public Fib(int first, int second)
		//{
			
		//}

		public int[] Calc(int count)
		{
			int[] result = new int[count];
			result[0] = _first;
			result[1] = _second;

			Calc(result, 2);
			return result;
		}

		static void Main(string[] args)
		{
			ConsoleGraphics g = new ConsoleGraphics();
			Console.CursorVisible = false;
			while (true)
			{
				g.FillRectangle(0xFF00FF00, 10, 10, 40, 40);
				g.FlipPages();
			}

		}
	}
}



