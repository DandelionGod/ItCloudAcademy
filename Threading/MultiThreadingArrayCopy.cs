using System;

namespace Threading
{
    public class MultiThreadingArrayCopy<T> : MultiThreadingArrayProcessor<T>
    {
        private readonly T[] _targetArr;

        public MultiThreadingArrayCopy(T[] sourceArr, T[] targetArr, int offset, int count, int threadNum)
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
