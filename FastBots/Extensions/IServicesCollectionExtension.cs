using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastBots.Extensions
{
    public static class IServicesCollectionExtension
    {
        public static IServiceCollection AddFastBotsLibrary(this IServiceCollection services)
        {
            return services;
        }
    }
}
