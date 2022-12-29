using BotDiscord.Fileconfig;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Domain.CommandHandlerModule;
using Infra.LodModule;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Infra.Initializer
{
    public class Initializer
    {
        public static ServiceProvider InitializerService()
        {

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<FileConfig>();
            services.AddHttpClient("RiotApi");

            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 500,
                LogLevel = LogSeverity.Info,
                GatewayIntents = GatewayIntents.All

            }));

            services.AddSingleton<CommandService>();
            services.AddSingleton<ICommandHandler, CommandHandler>();


            return services.BuildServiceProvider();

        }
    }
}
