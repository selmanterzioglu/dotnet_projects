using System;
using System.Threading.Tasks;


namespace Listing_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("hello world");
            });
            Console.WriteLine("main method complete.  please enter to finish");
            Console.ReadLine();
        }
    }
}
