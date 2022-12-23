using Discord.Commands;
using Discord.WebSocket;
using Infra.LodModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlerModule
{
    public class CommandHandler : ICommandHandler
    {
        private DiscordSocketClient _client { get; set; }
        private ILogger _log { get; set; }
        private CommandService _service { get; set; }
        public CommandHandler(ILogger log, DiscordSocketClient cliente, CommandService service)
        {
            _client = cliente;
            _log = log;
            _service = service;
            InitializeAsync();
            _client.MessageReceived += HandleCommandAsync;
        }

        public async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;

            if (messageParam.Source != Discord.MessageSource.User)
                return;

            var context = new SocketCommandContext(_client, message);

            int argPos = 0;

            if (messageParam.Author.IsBot || !message.HasCharPrefix('!', ref argPos))
                return;

            var result = await _service.ExecuteAsync(context, argPos, services: null);

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
        public async Task InitializeAsync()
            => await _service.AddModulesAsync(Assembly.GetEntryAssembly(), null);
    }
}
