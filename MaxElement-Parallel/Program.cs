using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxElement_Parallel
{
    class Program
    {

        public class ThreadParam
        {
            public int ThreadNum { get; set; }
            public int ThreadsCount { get; set; }
            public int Max { get; set; }
            public int[] Nums { get; set; }
        }

        static void ThreadMethod(Object obj)
        {
            var threadParam = (ThreadParam)obj;

            int max = FindMax(threadParam.Nums.Length / threadParam.ThreadsCount * threadParam.ThreadNum - threadParam.Nums.Length / threadParam.ThreadsCount,
                                threadParam.Nums.Length / threadParam.ThreadsCount * threadParam.ThreadNum, threadParam.Nums);

            if (threadParam.Max < max)
                threadParam.Max = max;

        }
        static int FindMax(int from, int to, int[] nums)
        {
            int max = int.MinValue;

            for (int i = from; i < to; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
            }

            return max;
        }
        static int FindMaxParallel(int threadCount, int[] nums)
        {
            Thread[] threads = new Thread[threadCount];
            ThreadParam[] threadParams = new ThreadParam[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(ThreadMethod);
                threadParams[i] = new ThreadParam {
                    Max = int.MinValue,
                    Nums = nums,
                    ThreadNum = i + 1,
                    ThreadsCount = threadCount

                };

                threads[i].Start(threadParams[i]);
            }

            for (int i = 0; i < threadCount; i++)
            {
                threads[i].Join();
            }

            var threadsMaxs = threadParams.Select(s1 => s1.Max).ToArray();
            return FindMax(0, threadsMaxs.Length, threadsMaxs);
        }
        static void Main(string[] args)
        {
            var r = new Random();
            var nums = Enumerable.Range(0, 100000)
                .Select(n => r.Next(0, 100000))
                .ToArray();

            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(FindMax(0, nums.Length, nums));
            Console.WriteLine(DateTime.Now.Millisecond);

            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(FindMaxParallel(4, nums)); //first parameter of "FindMaxParallel -> numbers of threads
            Console.WriteLine(DateTime.Now.Millisecond);

            Console.ReadKey();
        }
    }
}
