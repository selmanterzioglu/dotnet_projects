using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example8
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {

            int n = 1000000000;
            //int[] A = new int[n];
            //for (int i = 0; i < n; i++)
            //    A[i] = random.Next(2, 50);


            DateTime dt = DateTime.Now;
            //FillSequential(A);
            //FillParFor(A);

            int s = 0;
            object o = "";
            Parallel.For(0, n, i =>
            {
                //lock (o)
                s += 10;
            });
            //for (int i = 0; i < n; i++)
            //{
            //    s += 10;

            //}
            Console.WriteLine(s);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();
        }
        static void FillParFor(int[] A)
        {
            Parallel.For(0, A.Length, (i) =>
            {
                A[i] = Factorial(A[i]);
            });
        }

        static void FillSequential(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Factorial(A[i]);
            }
        }

        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}