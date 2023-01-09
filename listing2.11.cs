using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_11
{
    class listing2_11
    {
        static void main(string[] args)
        {
            // create the cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // create the cancellation token
            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationTokenSource tokenSource3 = new CancellationTokenSource();

            // create a composite token source using multiple tokens
            CancellationTokenSource compositeSource =
                CancellationTokenSource.CreateLinkedTokenSource(
                    tokenSource1.Token, tokenSource2.Token, tokenSource3.Token);

            // create a cancellable task using the composite token
            Task task = new Task(() =>
            {
                // wait until the token has been composite token
                compositeSource.Token.WaitHandle.WaitOne();
                // throw a cancellation exception
                throw new OperationCanceledException(compositeSource.Token);
            }, compositeSource.Token);


            // start the task
            task.Start();

            // cancel one of the original tokens
            tokenSource2.Cancel();

            // wait for input before exiting

            Console.WriteLine("main method complete. press enter to finish");
            Console.ReadLine();

        }
    }
}