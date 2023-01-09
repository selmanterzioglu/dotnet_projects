using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = 100000000;
            int core = 4;
            int[] dizi = new int[n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                dizi[i] = r.Next(1, 11);
                //Console.WriteLine(dizi[i]);
            }


            Task<int>[] t1 = new Task<int>[n];

            int segment = (int)Math.Ceiling((double)dizi.Length / core);

            DateTime dt = DateTime.Now;

            for (int i = 0; i < core; i++)
            {
                int start = i * segment;
                int end = Math.Min((i + 1) * segment, dizi.Length);

                t1[i] = new Task<int>(() => {

                    return toplam(dizi, start, end);



                });
                t1[i].Start();


            }

            Task.WaitAll();
            int sontoplam = 0;
            for (int i = 0; i < core; i++)
            {
                sontoplam += t1[i].Result;
            }
            Console.WriteLine($"dizinin toplamı {sontoplam}");
            Console.WriteLine($"toplam süre = {DateTime.Now - dt}");

            DateTime dt2 = DateTime.Now;

            int partop = ptoplam(dizi);
            Console.WriteLine($" dizinin paralel toplamı {partop}");

            Console.WriteLine($"toplam süre = {DateTime.Now - dt2}");

            Console.ReadLine();


        }
        static int toplam(int[] diz, int start, int end)
        {
            int topla = 0;
            for (int i = start; i < end; i++)
            {
                topla += diz[
I];

            }
            return topla
        }



        static int ptoplam(int[] diz)
        {
            int topla = 0;
            object o = "";
            Parallel.For(0, diz.Length, (i) => {
                lock (o)
                    topla += diz[
      I];

            })

        }
    }
}
;
return topla; ;