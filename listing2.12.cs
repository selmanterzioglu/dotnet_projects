using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_12
{
    class listing2_12
    {
        static void main(string[] args)
        {
            
            // create the cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // create the cancellation token 
            CancellationToken token1 = tokenSource.Token;

            //  create the task 
            Task task1 = new Task (() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token1.ThrowIfCancellationRequested();
                    Console.WriteLine("task 1- value {0}", i);
                }
            }, token1);

            // create the second cancellation token source 
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();

            // create the cancellation token
            CancellationToken token2 = tokenSource2.Token;

            // create the second task, which will be will cancel 
            Task task2 = new Task (() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token2.ThrowIfCancellationRequested();
                    Console.WriteLine("task2- int value {0}", i);
                }

            }, token2);

            // start all of the tasks
            task1.Start();
            task2.Start();

            // cancel the second token source
            tokenSource2.Cancel();

            //  write out the cancellation detail of each task 
            Console.WriteLine("task 1 cancelled ? {0}", task1.IsCanceled);
            Console.WriteLine("task 2 cancelled ? {0}", task2.IsCanceled);

            // wait for input before exiting
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();

        }
    }
}