using System;
using System.Threading.Tasks;
/*
* find minimum and maximum value on array that has 100 elements.
* your code must assign item for array. 
*/

namespace example2
{
    class example2
    {
        static void main(string[] args)
        {
            int[] array = new int[100];
            Random random = new Random();

            Task assign_task = new Task(() =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(0, 100);   
                }
            });

            Task<int> minimum_task = new Task<int>(() =>
            {
                int min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min =  array[i];
                    }
                }
                return min;
            });

            Task<int> average_task = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum+= array[i];
                }
                return sum / array.Length;
            });

           Task<int> maximum_task = new Task<int>(() =>
           {
               int max = array[0];
               for (int i = 0; i < array.Length; i++)
               {
                   if (array[i] > max)
                   {
                       max =array[i];
                   }
               }
               return max;
           });

            assign_task.Start();
            assign_task.Wait();
            
            minimum_task.Start();
            maximum_task.Start();
            average_task.Start();
            
            Console.WriteLine(minimum_task.Result);
            Console.WriteLine(maximum_task.Result);
            Console.WriteLine(average_task.Result);

            Console.Read();
        }
    }
}