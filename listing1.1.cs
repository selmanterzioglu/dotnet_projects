using System;
using System.Threading.Tasks;


namespace Listing1_1
{
    public class listing1_1
    {
        static void main(string[] args)
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
