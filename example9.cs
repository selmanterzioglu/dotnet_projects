using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example9
{

    // 2 adet counter olacak ( c1,c2 ) ikisi de 0dan baslayacak.
    // T1 taski başlayacak. T1 1 milyonu geçtiğinde T2 taski baslayacak. T1 5 milyon olduğunda cancel edip bitirecek.
    // T1 taski t2yi baslatacak mainden baslatilmayacak!

    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelToken1 = new CancellationTokenSource();
            //cancell token ımızı initilaize ediyoruz
            CancellationTokenSource cancelToken2 = new CancellationTokenSource();

            Task task1 = new Task(() =>
            {

                int i = 0;
                while (true)
                {

                    i++;
                    Console.WriteLine("1 sayaç = " + i);

                    if (i == 1000)
                    {
                        Task task2 = new Task(() =>
                        {

                            int y = 0;
                            while (true)
                            {
                                y++;
                                Console.WriteLine("2 sayaç = " + y);
                                if (cancelToken2.IsCancellationRequested)
                                {
                                    Console.WriteLine("durdu be yaaa :) ");
                                    break;
                                }
                            }


                        }, cancelToken2.Token);

                        task2.Start();

                    }

                    if (i == 5000)
                        cancelToken2.Cancel();
                    if (i == 7000)
                        cancelToken1.Cancel();
                    if (cancelToken1.IsCancellationRequested)
                    {
                        break;
                    }
                    // break;
                }

            }, cancelToken1.Token

            );

            task1.Start();
            Console.ReadLine();

        }
    }
}