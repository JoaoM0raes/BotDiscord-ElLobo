using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.LodModule
{
    public class Logger : ILogger
    {
        public Logger(DiscordSocketClient client, CommandService command)
        {
            client.Log += LogAsync;
            command.Log += LogAsync;
        }

        public Task LogAsync(LogMessage message)
        {
            LogConsole(message.ToString());

            return Task.CompletedTask;
        }

        public void LogConsole(string message)
        {
            Console.WriteLine(message);
        }



        public void LogFile()
        {
            throw new NotImplementedException();
        }
    }
}
