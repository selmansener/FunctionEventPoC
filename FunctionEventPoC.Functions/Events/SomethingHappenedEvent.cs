using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionEventPoC.Functions.Events
{
    public class SomethingHappenedEvent : INotification
    {
        public SomethingHappenedEvent(DateTime raisedAt)
        {
            RaisedAt = raisedAt;
            Console.WriteLine($"{nameof(SomethingHappenedEvent)} raised at {raisedAt}");
        }

        public DateTime RaisedAt { get; private set; }
    }
}
