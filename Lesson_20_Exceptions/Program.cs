using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_20_Exceptions
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				throw new IndexOutOfRangeException();
			}
			catch(IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.StackTrace);
				Console.WriteLine(ex.Message);
			}
			catch(SystemException se)
			{
				Console.WriteLine(se.Message);
			}
			Console.ReadKey();
		}
	}
}
