using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_26_Task
{
	public class MultiThreadingRandom : MultiTaskArrayProcessor<int>
	{
		public MultiThreadingRandom(int[] arr, int threadNum)
			: base(arr, threadNum)
		{
		}

		protected override void InternalProcess(int start, int end)
		{
			var random = new Random();
			for (int i = start; i < end; i++)
			{
				_arr[i] = random.Next();
			}
		}
	}
}
