using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.CommandsModules
{
    public class UtilityModel : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public async Task SayAsyc()
        {
            await ReplyAsync("vasco");
        }
            
    }
}
