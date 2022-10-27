using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Template {
    internal  class Template {
        static void Main(String[] args)
        {
                
        }
        static double Avarage (int[] x) 
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++){res += x[i];}
            return res / x.Length;
        }
    }
}