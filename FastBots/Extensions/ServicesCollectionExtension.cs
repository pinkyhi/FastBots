using FastBots.Types;
using FastBots.Types.Commands;
using FastBots.Types.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FastBots.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddFastBots(this IServiceCollection services, FastBotsOptions options)
        {
            services.AddSingleton(options);
            services.AddSingleton<CommandTree>();
            services.AddSingleton<BotClient>();
            return services;
        }
    }
}
