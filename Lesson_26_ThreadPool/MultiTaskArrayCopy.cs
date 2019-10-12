using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_26_Task
{
	public class MultiTaskArrayCopy<T> : MultiTaskArrayProcessor<T>
	{
		private readonly T[] _targetArr;

		public MultiTaskArrayCopy(T[] sourceArr, T[] targetArr, int offset, int count, int threadNum)
			: base(sourceArr, threadNum, Math.Max(0, offset), count <= 0 ? targetArr.Length : Math.Min(count, targetArr.Length))
		{
			_targetArr = targetArr;
		}

		protected override void InternalProcess(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				_targetArr[i - _offset] = _arr[i];
			}
		}
	}
}

