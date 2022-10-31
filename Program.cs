using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program {
    internal  class Program {
        static void Main(String[] args)
        {
            int[] a = new int []{1, 8, 2, 9};
                
        }
        static double Avarage (int[] x) 
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++){res += x[i];}
            return res / x.Length;
        }

        static int Max(int[] x)
        {
            int max = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if(x[i] > max)
                    max = x[i];
            }
            return max; 
        }
    }
}