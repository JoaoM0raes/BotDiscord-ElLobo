using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Infra.LogModule
{
    public interface ILog
    {
        public Task LogAsync(LogMessage message);        

        public void Info (string message);

        public void Error (string message);
    }
}
