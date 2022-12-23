using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlerModule
{
    public interface ICommandHandler
    {
        public Task HandleCommandAsync(SocketMessage messageParam);
        public Task InitializeAsync();
    }
}
