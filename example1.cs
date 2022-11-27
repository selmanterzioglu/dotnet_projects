using System;
using System.Threading.Tasks;

namespace example1
{
    class example1
    {
        
        static void main(string[] args)
        {
            int[] array = new int[100];
            int n = 4;
            int L = array.Length;
            int segmentLength = (int)Math.Ceiling((decimal)L / n);
            Console.WriteLine("segment_length: " + segmentLength);

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int start = i * segmentLength;
                int end = Math.Min(((i+1) * segmentLength), L);
                Task new_thread = new Task(()=>
                {
                    send_array(array, start, end, start);
                });
                new_thread.Start();
            }
            Console.ReadLine();
        }

        static void send_array(int[] array, int start, int end, object message)
        {
            Random random = new Random();
            for (int i = start; i < end; i++)
            {
                array[i] = random.Next(0, 100);
                Console.WriteLine(message + "  " + array[i]);
            }
        }
    }
}