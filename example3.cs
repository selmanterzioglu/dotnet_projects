using System;
using System.Threading.Tasks;

namespace example3
{
    class example3
    {
        static void main(string[] args)
        {
            int n = 100;
            int core = 4;
            int start = 0, end= 0, last_sum = 0;
            int[] array = new int[n];
            Random random = new Random();    

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-500, 500);
            }

            int segment = (int)Math.Ceiling((decimal) n/core);
            Task<int>[] assign_task = new Task<int>[core];
            for (int i = 0; i < core; i++)
            {
                start = i * segment;
                end = Math.Min((i+1)*segment,n);
                assign_task[i] = new Task<int>(() =>
                {
                    return sum_func(array, start, end);
                });
                assign_task[i].Start(); 
            }
            Task.WaitAll();
            for (int i = 0; i < core; i++)
            {
                last_sum += assign_task[i].Result;
            }
            Console.WriteLine(last_sum);
            Console.Read();
        }
        static int sum_func(int[] array, int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += array[i];
            }
            return sum; 
        }
    }
}