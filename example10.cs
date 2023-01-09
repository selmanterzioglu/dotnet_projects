using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100000000;
            double[] A = new double[n];

            DateTime dt = DateTime.Now;
            FillArray(A);
            Console.WriteLine($"Sequential: {DateTime.Now - dt}");

            dt = DateTime.Now;
            FillArrayParallel(A);
            Console.WriteLine($"Parallel: {DateTime.Now - dt}");

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
        static Random rnd = new Random();
        static void FillArrayParallel(double[] A)
        {
            Parallel.For(0, A.Length, (i) =>
            {
                int r = rnd.Next(5, 100);
                A[i] = F(i, r);
            });
        }
        static void FillArray(double[] A)
        {
            // random
            for (int i = 0; i < A.Length; i++)
            {
                int r = rnd.Next(5, 100);
                A[i] = F(i, r);
            }
        }
        static double F(int x, int r)
        {
            double result = 0;
            for (int i = 5; i <= r; i++)
            {
                result += (double)(i) / (x * x - x + i);
            }

            return result;

        }
    }
}