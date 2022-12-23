using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.LodModule
{
    public interface ILogger
    {
        public Task LogAsync(LogMessage message);

        public void LogFile();

        public void LogConsole(string message);
    }
}
