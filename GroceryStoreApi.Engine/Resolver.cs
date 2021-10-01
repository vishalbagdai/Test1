using GroceryStoreApi.Engine.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStoreApi.Engine
{
    public static class Resolver
    {
        public static IServiceCollection AddEngineDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConsumersEngine, ConsumersEngine>();
            return serviceCollection;
        }
    }
}
