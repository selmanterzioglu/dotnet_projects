using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_9
{
    class listing2_9
    {
        static void main(string[] args)
        {
           
            // create the cancellation token source 
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // create the cancellation token
            CancellationToken token = tokenSource.Token;

            //  create the task
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("task cancel detected");
                        throw new OperationCanceledException();

                    }
                    else
                    {
                        Console.WriteLine("Int Value {0}", i);
                    }
                }
            }, token);

            // create a second task that will use the wait handle 
            Task task2 = new Task(() =>
            {
                token.WaitHandle.WaitOne();
                // write out a message 
                Console.WriteLine(">>>>> wait handle released");
            });

            // wait for input before we start the task
            Console.WriteLine("Press enter to start task");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();

            // start the task
            task1.Start();
            task2.Start();

            // read a line from the console.
            Console.ReadLine();

            // read a line from the console
            Console.WriteLine("cancelling task");
            tokenSource.Cancel();

            // wait for input before exiting
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();

        }
    }
}