using GroceryStoreApi.Processor.interfaces;
using GroceryStoreApi.Processor.mapper;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreApi.Processor
{
    public static class Resolver
    {
        public static IServiceCollection AddProcessorDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConsumersProcessor, ConsumersProcessor>();
            return serviceCollection;
        }
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ConsumerMapperProfile));
        }
    }
}
