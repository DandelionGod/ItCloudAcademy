using System;
using System.Threading;

namespace Threading
{
    public class MultiThreadingRandom : MultiThreadingArrayProcessor<int>
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
