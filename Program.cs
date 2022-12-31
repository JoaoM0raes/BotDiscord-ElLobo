
using BotDiscord.Infra.FileConfigs;
using BotDiscord.Infra.Initializer;
using Discord;
using Discord.WebSocket;
using Domain.CommandHandlerModule;
using Microsoft.Extensions.DependencyInjection;

namespace BotDiscord
{
    internal class Program
    {
        private DiscordSocketClient _client;
        private FileConfig _config;
        private ICommandHandler _commandHandler;

        static Task Main(string[] args)
        {
            return new Program().MainTask();
        }
        public async Task MainTask()
        {
            var services =ConstructObejects();

            await _client.LoginAsync(TokenType.Bot, _config.Token);

            await _client.StartAsync();

            services.GetRequiredService<ICommandHandler>();
            
            await Task.Delay(-1);
        }
        private IServiceProvider ConstructObejects()
        {
            var services = Initializer.InitializerService();

            _client = services.GetRequiredService<DiscordSocketClient>();
            _config = services.GetRequiredService<FileConfig>();
            
            return services;
        }
    }
}