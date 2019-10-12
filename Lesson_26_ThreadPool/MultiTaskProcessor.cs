using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_26_Task
{
	public abstract class MultiTaskArrayProcessor<T>
	{
		protected readonly T[] _arr;
		private readonly int _threadCount;
		private readonly int _count;
		protected readonly int _offset;

		public MultiTaskArrayProcessor(T[] arr, int threadNum, int offset = 0, int count = 0)
		{
			if (threadNum <= 0)
				throw new ArgumentOutOfRangeException(nameof(threadNum));
			if (arr == null || arr.Length < threadNum)
				throw new ArgumentException($"Parameter {nameof(arr)} has invalid state.");

			_arr = arr;
			_threadCount = threadNum;
			_offset = offset;
			if (count <= 0)
				_count = _arr.Length;
			else
				_count = count;
		}

		public void Start()
		{
			Task[] tasks = new Task[_threadCount];
			for (int i = 0; i < _threadCount; i++)
			{
				var j = i;
				tasks[i] = Task.Run(() => (j));
			}
			Task.WaitAll(tasks);
		}

		private void Proc(object state)
		{
			var currentThreadNumber = (int)state;

			var countItems = _count / _threadCount;
			int start = _offset + currentThreadNumber * countItems;
			int end = start + countItems;

			if (currentThreadNumber == _threadCount - 1)
				end = _offset + _count;

			InternalProcess(start, end);
		}

		protected abstract void InternalProcess(int start, int end);
	}
}

