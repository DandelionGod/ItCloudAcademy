using System;

namespace Threading
{
    public class MultiThreadingGenByFunc<T> : MultiThreadingArrayProcessor<T>
    {
        private readonly Func<int, T> _generator;

        public MultiThreadingGenByFunc(T[] arr, int threadNum, Func<int, T> generator)
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
