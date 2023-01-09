using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100000000;
            int[] A = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = n - i;
            }

            int x = 25000000 - 9;
            int coreCount = 4;

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            //CancellationToken token = tokenSource.Token;

            Task<int>[] tasks = new Task<int>[coreCount];
            int segmentLength = (int)Math.Ceiling(A.Length / (double)coreCount);
            for (int i = 0; i < coreCount; i++)
            {
                int start = i * segmentLength, end = Math.Min((i + 1) * segmentLength, A.Length);
                tasks[i] = new Task<int>(() =>
                {
                    return LinearSearch(A, x, start, end, tokenSource);
                }, tokenSource.Token);
                tasks[i].Start();
            }
            // create the task 


            //Task.WaitAll(tasks);
            DateTime dt = DateTime.Now;
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"Task {i} returns {tasks[i].Result}");
            }


            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();

        }


        static int LinearSearch(int[] a, int x, int start, int end, CancellationTokenSource tokenSource)
        {
            for (int j = start; j < end; j++)
            {
                if (tokenSource.Token.IsCancellationRequested) return -2;
                if (a[j] == x)
                {
                    Console.WriteLine("Found at " + j);
                    tokenSource.Cancel();
                    return j;
                }
                for (int i = 0; i < 50; i++)
                {
                }
                //Console.Write(".");
            }
            return -1;
        }
    }
}