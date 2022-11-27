using System;
using System.Threading.Tasks;

namespace listing2_3
{
    class listing2_3
    {
        static void print_message(object message)
        {
            Console.WriteLine("message: {0}", message);
        }

        static void main(string[] args)
        {
            Task task1 = new Task(new Action<object>(print_message),
                "first task");
            Task task2 = new Task(delegate(object obj)
            {
                print_message(obj);
            }, "second task");
            Task task3 = new Task((obj) => print_message(obj), "third task ");

            Task task4 = new Task((obj) =>
            {
                print_message(obj);
            }, "fourth task");

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            Console.WriteLine("main method complete ! ");
            Console.ReadLine();
        }
    }
}