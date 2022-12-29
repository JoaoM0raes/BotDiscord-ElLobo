using BotDiscord.Infra.FileConfig;
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
            ConstructObejects();

            await _client.LoginAsync(TokenType.Bot, _config.Token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }
        private void ConstructObejects()
        {
            var services = Initializer.InitializerService();

            _client = services.GetRequiredService<DiscordSocketClient>();
            _config = services.GetRequiredService<FileConfig>();
            _commandHandler = services.GetRequiredService<ICommandHandler>();
        }
    }
}