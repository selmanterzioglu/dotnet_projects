using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing2_7
{
    class listing2_7
    {
        static void main(string[] args)
        {
            // create the cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            
            // create the cancellation token    
            CancellationToken token = tokenSource.Token;

            //create the task
            Task task = new Task(() =>{
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("task cancel detected");
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.WriteLine("Int Value {0}", i);
                    }
                }
            }, token);

            // wait for input before we start the task 
            Console.WriteLine("press enter to start task");
            Console.WriteLine("press enter again to cancel task");
            Console.ReadLine();

            // start the task   
            task.Start();

            // read a line from the console
            Console.ReadLine(); 
            
            // cancel the task  
            Console.WriteLine("cancelling task");
            tokenSource.Cancel();

            // wait for input before exiting 
            Console.WriteLine("main method complete.  press enter to finish");
            Console.ReadLine();

        }
    }
}