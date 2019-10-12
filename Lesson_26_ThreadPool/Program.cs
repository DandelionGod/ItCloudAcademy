using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_26_Task
{
	class Program
	{
		static void Main(string[] args)
		{
			//Random r = new Random();
			//int[] arr = new int[500000000];

			Stopwatch stopwatch = new Stopwatch();
			//stopwatch.Start();

			//var multiRandom = new MultiThreadingRandom(arr, 6);
			//multiRandom.Start();

			//stopwatch.Stop();
			//Console.WriteLine("Random in two thread: " + stopwatch.Elapsed);

			int[] arr = Enumerable.Range(1, 200000000).ToArray();
			int[] result = new int[100000000];

			stopwatch.Start();

			var multi = new MultiTaskArrayCopy<int>(arr, result, 2000000, 0, 1);
			multi.Start();

			stopwatch.Stop();
			Console.WriteLine("Random in two thread: " + stopwatch.Elapsed);

			Console.ReadKey();
		}
	}
}
