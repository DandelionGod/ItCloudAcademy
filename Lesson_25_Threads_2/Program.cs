using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_25_Threads_2
{
	class MultithreadingRAndom
	{
		private readonly Random _random = new Random();
		private readonly int[] _arr;
		private readonly int _threadCount;

		public MultithreadingRAndom(int[] arr, int threadNum)
		{
			if (threadNum <= 0)
				throw new ArgumentOutOfRangeException(nameof(threadNum));
			if (arr == null || arr.Length < threadNum)
				throw new ArgumentException($"Parametr {nameof(arr)} has invalid state");
			_arr = arr;
			_threadCount = threadNum;
		}

		public void Start()
		{

			Thread[] threads = new Thread[_threadCount];
			for (int i = 0; i < _threadCount; i++)
			{
				threads[i] = new Thread(Proc);
			}

			for (int i = 0; i < _threadCount; i++)
			{
				threads[i].Start(i);
			}

			for (int i = 0; i < _threadCount; i++)
			{
				threads[i].Join();
			}

		}

		private void Proc(object state)
		{

			int currentThreadNumber = (int)state;
			Random random = new Random(currentThreadNumber);

			int start = currentThreadNumber * _arr.Length / _threadCount;
			int end = start + (_arr.Length / _threadCount);

			if (currentThreadNumber == _threadCount - 1)
				end = _arr.Length;

			for (int i = start; i < end; i++)
			{
				_arr[i] = random.Next();
			}
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			Random r = new Random();
			int[] arr = new int[500000000];

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			var multiRandom = new MultithreadingRAndom(arr, 4);
			multiRandom.Start();

			stopwatch.Stop();
			Console.WriteLine("Random is one thread: " + stopwatch.Elapsed);

			Console.ReadLine();
		}
	}
}
