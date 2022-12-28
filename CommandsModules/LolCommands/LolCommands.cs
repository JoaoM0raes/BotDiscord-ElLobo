using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.CommandsModules.LolCommands
{
    public class LolCommands : ModuleBase<SocketCommandContext>
    {
        private LolApi _lolApi; 

        public LolCommands(LolApi lolApi)
        {
            _lolApi = lolApi;
        }

        [Command("jogador")]
        public async Task GetJogadorAsync(string playerName)
        {
            try
            {
              var player = _lolApi.GetPlayerId(playerName);

              player.stats = _lolApi.GetPlayerRanks(player);

              

            }
            catch (Exception ex)
            {


            }
        }

    }
}
