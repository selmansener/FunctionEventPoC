using AzureFunctions.Extensions.SimpleDependencyInjection;
using FunctionEventPoC.Functions.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FunctionEventPoC.Functions
{
    public class ServiceProviderBuilder : IContainerConfigurator
    {
        public void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(SomethingHappenedEvent).GetTypeInfo().Assembly);
        }
    }
}
