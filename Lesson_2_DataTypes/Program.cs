using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_DataTypes
{
	class Program
	{
		enum Week { sunday, monday, thusday, wensday, thersday, friday, saturday }

		static void Main(string[] args)
		{
			//var v = 10u;
			//float f = 2.5f;
			//decimal d = 3452345234654356m;
			//Console.WriteLine(@"hello ");
			//Console.WriteLine($"hello {v}");
			//Console.WriteLine("hello" + " " + v);
			//Console.WriteLine("hello {1} {2}", a, f);

			//int x = 3, y = 4;

			//x = x + y;
			//y = x - y;
			//x = x - y;

			//Console.WriteLine($"x = {x}, y = {y}");

			// --------------------Convert Types------------------------

			//int test2 = 0;
			//object obj = test2;
			//long res = (int)obj;

			//Console.WriteLine("Enter age:");
			//var userAge = Console.ReadLine();
			//int age;
			//int r;
			//if (int.TryParse(userAge, out r))
			//{
			//	age = r;
			//}
			//string x = null, y = null;
			//int a = 0, b = 0,  sum = 0;
			//Console.WriteLine("Entr x and y:");
			//x = Console.ReadLine();
			//y = Console.ReadLine();
			////C onsole.Read();
			//a = Convert.ToInt32(x);
			//b = Convert.ToInt32(y);
			//sum = a + b;

			// ------------------Operator If------------------------------

			//Console.WriteLine("Input number: ");

			//var num = Console.ReadLine();

			//if(int.TryParse(num, out var r))
			//{
			//	Console.WriteLine(r * 2);
			//}
			//else
			//{
			//	Console.WriteLine("Incorrect input");
			//}

			var numDay = Console.ReadLine();
			if (int.TryParse(numDay, out var r) && r < 7 && r >= 0)
			{
				switch ((Week)r)
				{
					case Week.sunday:
						Console.WriteLine("Sunday");
						break;
					case Week.monday:
						Console.WriteLine("Monday");
						break;
					case Week.wensday:
						Console.WriteLine("Wensday");
						break;
					case Week.thusday:
						Console.WriteLine("Thersday");
						break;
					case Week.thersday:
						Console.WriteLine("Friday");
						break;
					case Week.saturday:
						Console.WriteLine("Saturday");
						break;
				}
			}

			//var baseType = 1.5;
			//var type = baseType as int;

			Console.WriteLine();
			Console.ReadKey();
		}
	}
}
