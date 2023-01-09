using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_10
{
    class listing2_10
    {
        static void main(string[] args)
        {

            // craete the cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // create the cancellation token
            CancellationToken token = tokenSource.Token;

            // create the task
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("task 1- Int value {0}", i);
                }
            }, token);

            Task task2 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("task 2- Int value {0}", i);
                }
            }, token);

            // wait for input before we start the tasks 
            Console.WriteLine("Press enter to start tasks");
            Console.WriteLine("Press enter again to cancel tasks");
            Console.ReadLine();

            // start the tasks
            task1.Start();  
            task2.Start();

            // read a line from the console. 
            Console.ReadLine();

            // cancel  the task 
            Console.WriteLine("cancelling task..");
            tokenSource.Cancel();

            // wait for input before exiting
            Console.WriteLine("main method complete. press enter to finish the program...");
            Console.ReadLine();
        }
    }
}