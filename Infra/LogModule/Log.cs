using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BotDiscord.Infra.LogModule
{
    public class Log : ILog
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        public Log(DiscordSocketClient client, CommandService command)
        {            
            client.Log += LogAsync;
            command.Log += LogAsync;
        }

        public Task LogAsync(LogMessage message) //using discord log for consoles logs
        {
            Console.WriteLine(message);
            
            return Task.CompletedTask;
        }

        public void Info(string message)  //usign Nlog for files logs
        {
            logger.Info(message);
        }
        public void Error(string message)
        {
            logger.Error(message);
        }

       
    }
}
