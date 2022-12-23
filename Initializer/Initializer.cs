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

namespace BotDiscord.Initializers
{
    public class Initializer
    {
        public static ServiceProvider InitializerService()
        {
            IServiceCollection service = new ServiceCollection();

            service.AddSingleton<ILogger, Logger>();
            service.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 500,
                LogLevel = LogSeverity.Info,
                GatewayIntents=GatewayIntents.All
                
            }));
            service.AddSingleton<CommandService>();
            service.AddSingleton<ICommandHandler, CommandHandler>();
            service.AddSingleton<FileConfig>();

            return service.BuildServiceProvider();

        }
    }
}
