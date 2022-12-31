using BotDiscord.Infra.Initializer;
using BotDiscord.Infra.LogModule;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domain.CommandHandlerModule
{
    public class CommandHandler : ICommandHandler
    {
        private DiscordSocketClient _client { get; set; }
        private ILog _log { get; set; }
        private CommandService _command{ get; set; }

        private IServiceProvider _services { get; set; }
        public CommandHandler(DiscordSocketClient cliente,IServiceProvider services)
        {            
            _client = cliente;
            
            _command = services.GetRequiredService<CommandService>();
            
            _log = services.GetRequiredService<ILog>();

            _services = services;

            Initialize();

            _client.MessageReceived += HandleMessageAsync;

            
        }

        public async Task HandleMessageAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;

            if (messageParam.Source != Discord.MessageSource.User)
                return;

            var context = new SocketCommandContext(_client, message);

            int argPos = 0;

            if (messageParam.Author.IsBot || !message.HasCharPrefix('!', ref argPos))
                return;

            var result = await _command.ExecuteAsync(context, argPos, _services);

            await HandleError(result, context);

        }

        private async Task HandleError(IResult result, SocketCommandContext context)
        {
            if (!result.IsSuccess && result.Error.HasValue)
            {
                await context.Channel.SendMessageAsync($":x: {result.ErrorReason}");
                return;
            }
            return;
        }

        public async Task Initialize()
        {
            await _command.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                    _services);
        }

    }
}
