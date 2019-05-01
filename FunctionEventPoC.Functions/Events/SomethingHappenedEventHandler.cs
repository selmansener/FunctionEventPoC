using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionEventPoC.Functions.Events
{
    public class SomethingHappenedEventHandler : INotificationHandler<SomethingHappenedEvent>
    {
        public async Task Handle(SomethingHappenedEvent notification, CancellationToken cancellationToken)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"{nameof(SomethingHappenedEventHandler)} handled {nameof(SomethingHappenedEvent)} at: {DateTime.UtcNow}");

            await Task.CompletedTask;
        }
    }
}
