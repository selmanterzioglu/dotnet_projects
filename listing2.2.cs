using System;
using System.Threading.Tasks;


namespace listing2_2
{
    public class listing2_2
    {
        static void print_message()
        {
            Console.WriteLine("hello world");
        }
        static void main(string[] args)
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
