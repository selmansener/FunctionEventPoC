using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionEventPoC.Functions.Events
{
    class AnotherSomthingHappenedEventHandler : INotificationHandler<SomethingHappenedEvent>
    {
        public async Task Handle(SomethingHappenedEvent notification, CancellationToken cancellationToken)
        {
            Thread.Sleep(2500);
            Console.WriteLine($"{nameof(AnotherSomthingHappenedEventHandler)} handled {nameof(SomethingHappenedEvent)} at: {DateTime.UtcNow}");

            await Task.CompletedTask;
        }
    }
}
