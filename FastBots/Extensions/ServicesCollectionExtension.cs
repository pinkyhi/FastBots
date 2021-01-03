using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastBots.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddFastBotsLibrary(this IServiceCollection services)
        {
            return services;
        }
    }
}
