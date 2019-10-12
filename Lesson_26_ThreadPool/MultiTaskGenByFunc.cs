using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_26_Task
{
	public class MultiTaskGenByFunc<T> : MultiTaskArrayProcessor<T>
	{
		private readonly Func<int, T> _generator;

		public MultiTaskGenByFunc(T[] arr, int threadNum, Func<int, T> generator)
			: base(arr, threadNum)
		{
			_generator = generator;
		}

		protected override void InternalProcess(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				_arr[i] = _generator(i);
			}
		}
	}
}
