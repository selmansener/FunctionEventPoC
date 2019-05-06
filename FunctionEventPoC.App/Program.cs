using System;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionEventPoC.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Main ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            //DoJob();

            Parallel.Invoke(
                () => Run(), 
                () => Run()
            );
            Console.WriteLine("Done");
            Console.Read();
        }

        private static async Task Run()
        {
            while (true)
            {
                Console.WriteLine($"TaskId: {Task.CurrentId}");
                await Task.Delay(1000);
            }
        }

        private static async void DoJob()
        {
            int counter = 0;
            while (counter < 5)
            {
                
                //Thread.Sleep(2000);
                Console.WriteLine($"Async method ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(2000);
                //await Task.CompletedTask;
                counter++;
            }
            throw new Exception("Error");
        }
    }
}
