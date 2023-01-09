using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_14
{
    class listing2_14
    {
        static void main(string[] args)
        {
           
            // create the cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // create the cancellation token
            CancellationToken token = tokenSource.Token;    

            //  create the task 

            Task task = new Task (() =>
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    // put the task to sleep for 10 seconds 
                    Thread.Sleep (10000);    
                    // print out a message 
                    Console.WriteLine("task 1 - Int Value {0}",i);
                    token.ThrowIfCancellationRequested();
                }
            }, token);

            // start the task
            task.Start();

            // wait for input before exiting
            Console.WriteLine("Press enter to cancel token.");
            Console.ReadLine();

            // cancel the token
            tokenSource.Cancel();


            // wait for input before exiting
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
        }
    }
}