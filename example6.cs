using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelToken = new CancellationTokenSource();
            int n = 100000000;
            int[] A = new int[n];
            for (int i = 0; i < n; i++) A[i] = i;

            int x = 76766607;

            int coreCount = 4;
            Task<int>[] tasks = new Task<int>[coreCount];
            int segmentLength = (int)Math.Ceiling(A.Length / (double)coreCount);
            for (int i = 0; i < coreCount; i++)
            {
                int start = i * segmentLength;
                int end = Math.Min((i + 1) * segmentLength, A.Length);
                tasks[i] = new Task<int>(() =>
                {
                    return LinearSearch(A, x, start, end, cancelToken);
                }, cancelToken.Token);
                tasks[i].Start();
            }

            DateTime dt = DateTime.Now;
            for (int i = 0; i < coreCount; i++)
            {
                Console.WriteLine($"Task No {i} is finished. Result is {tasks[i].Result}");
            }
            Console.WriteLine($"Duration: {DateTime.Now - dt}");


            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        static int LinearSearch(int[] a, int key, int start, int end, CancellationTokenSource cts)
        {
            for (int i = start; i < end; i++)
            {
                if (cts.IsCancellationRequested) return -2;
                if (a[i] == key)
                {
                    cts.Cancel();
                    return i;
                }

                for (int j = 0; j < 500; j++) { }
            }
            return -1;
        }
    }
}