using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example4
{
    class TreeResult
    {
        public double MinTree;
        public double MaxTree;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] A = new double[] { 1, 6, 4, 2, 8, 2, 3, 9.3, 1.5, 2.4 };
            int coreCount = 4;
            // Segment
            int segmentLength = (int)Math.Ceiling(A.Length / (double)coreCount);

            //Task definition
            Task<TreeResult>[] tasks = new Task<TreeResult>[coreCount];
            for (int i = 0; i < coreCount; i++)
            {
                int start = i * segmentLength;
                int end = Math.Min((i + 1) * segmentLength, A.Length);
                tasks[i] = new Task<TreeResult>(() =>
                {
                    return FindMinMaxTree(A, start, end);
                });
                tasks[i].Start();
            }

            // Wait
            Task.WaitAll(tasks);

            // Min Max
            double min = tasks[0].Result.MinTree, max = tasks[0].Result.MaxTree;

            for (int i = 1; i < coreCount; i++)
            {
                if (tasks[i].Result.MinTree < min) min = tasks[i].Result.MinTree;
                if (tasks[i].Result.MaxTree > max) max = tasks[i].Result.MaxTree;
            }

            // Difference
            Console.WriteLine(max - min);
            Console.ReadLine();
        }

        static TreeResult FindMinMaxTree(double[] a, int start, int end)
        {
            double min = a[start], max = a[start];

            for (int i = start + 1; i < end; i++)
            {
                if (a[i] < min) min = a[i];
                if (a[i] > max) max = a[i];
            }
            return new TreeResult() { MinTree = min, MaxTree = max };
        }

        static void Main2(string[] args)
        {
            double[] A = new double[] { 1, 6, 4, 2, 8, 2, 3, 9, 1.5, 2.4 };
            int coreCount = 4;
            // Segment
            int segmentLength = (int)Math.Ceiling(A.Length / (double)coreCount);

            //Task definition
            Task<double[]>[] tasks = new Task<double[]>[coreCount];
            for (int i = 0; i < coreCount; i++)
            {
                int start = i * segmentLength;
                int end = Math.Min((i + 1) * segmentLength, A.Length);
                tasks[i] = new Task<double[]>(() =>
                {
                    return FindMinMax(A, start, end);
                });
                tasks[i].Start();
            }

            // Wait
            Task.WaitAll(tasks);

            // Min Max
            double min = tasks[0].Result[0], max = tasks[0].Result[1];

            for (int i = 1; i < coreCount; i++)
            {
                if (tasks[i].Result[0] < min) min = tasks[i].Result[0];
                if (tasks[i].Result[1] > max) max = tasks[i].Result[1];
            }

            // Difference
            Console.WriteLine(max - min);
            Console.ReadLine();
        }

        static double[] FindMinMax(double[] a, int start, int end)
        {
            double min = a[start], max = a[start];

            for (int i = start + 1; i < end; i++)
            {
                if (a[i] < min) min = a[i];
                if (a[i] > max) max = a[i];
            }
            return new double[] { min, max };
        }
        static void Main1(string[] args)
        {
            double[] A = new double[] { 1, 6, 4, 2, 8, 2, 3, 9, 1.5, 2.4 };
            int coreCount = 4;


            // Segment
            int segmentLength = (int)Math.Ceiling(A.Length / (double)coreCount);

            //Task definition
            Task<int>[] tasks = new Task<int>[coreCount];
            for (int i = 0; i < coreCount; i++)
            {
                int start = i * segmentLength;
                int end = Math.Min((i + 1) * segmentLength, A.Length);
                tasks[i] = new Task<int>(() =>
                {
                    return FindTrees(A, start, end);
                });
                tasks[i].Start();
            }
            //Wait
            Task.WaitAll(tasks);

            //Sum results
            int treeCount = 0;
            for (int i = 0; i < coreCount; i++)
            {
                treeCount += tasks[i].Result;
            }

            Console.WriteLine(treeCount);
            Console.ReadLine();
        }
        static int FindTrees(double[] a, int start, int end)
        {
            int count = 0;
            for (int i = start; i < end; i++)
            {
                if (a[i] >= 2 && a[i] <= 4)
                    count++;
            }
            return count;
        }
    }
}