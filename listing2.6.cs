using System;
using System.Threading.Tasks;

namespace Listing_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task1 = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i<100; i++)
                {
                    sum += i;
                }
                return sum;
            });
            task1.Start();
            Console.WriteLine(task1.Result);
            Console.Read();
        }
    }
}