using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using FunctionEventPoC.Functions.Events;
using AzureFunctions.Extensions.SimpleDependencyInjection;
using System.Threading;

namespace FunctionEventPoC.Functions
{
    public static class RaiseEventFunction
    {
        [FunctionName(nameof(RaiseEventFunction))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            [Inject]IMediator mediator)
        {
            //mediator.Publish(new SomethingHappenedEvent(DateTime.UtcNow));

            Task.Factory.StartNew(DoJob, TaskCreationOptions.DenyChildAttach);

            //Task.Factory.StartNew(() =>
            //{
            //    mediator.Publish(new SomethingHappenedEvent(DateTime.UtcNow));
            //});

            await Task.CompletedTask;

            return new OkResult();
        }

        private static async void DoJob()
        {
            int counter = 0;
            while (counter < 5)
            {
                Console.WriteLine($"I'm working... Time is {DateTime.UtcNow}");
                Thread.Sleep(2000);
                await Task.CompletedTask;
                counter++;
            }
            throw new Exception("Error");
        }
    }
}
