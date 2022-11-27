using System;
using System.Threading.Tasks;


namespace Listing_02
{
    public class Program
    {
        static void print_message()
        {
            Console.WriteLine("hello world");
        }
        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(print_message));
            Task task2 = new Task(delegate {
                print_message();                
            });
            Task task3 = new Task(() => print_message());
            Task task4 = new Task(() =>
            {
                print_message();
            });
            task1.Start();  
            task2.Start();  
            task3.Start();  
            task4.Start();
            Console.WriteLine("main method complete!");
            Console.ReadLine();    

        }
    }
}
