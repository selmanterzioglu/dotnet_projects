using System;
using System.Threading.Tasks;

namespace listing2_6
{
    class listing2_6
    {
        static void main(string[] args)
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