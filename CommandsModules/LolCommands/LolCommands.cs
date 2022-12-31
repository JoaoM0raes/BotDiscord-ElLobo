using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.CommandsModules.LolCommands
{
    public class LolCommands : ModuleBase
    {
        private LolApi _lolApi; 

        public LolCommands(LolApi lolApi)
        {
            _lolApi = lolApi;
        }

        [Command("jogador")]
        public async Task GetJogadorAsync(string playerName)
        {            
           var player =  await _lolApi.GetPlayerId(playerName);

           player.stats = await _lolApi.GetPlayerRanks(player);


           foreach (var item in player.stats)
            {
                var embed = new EmbedBuilder()
                  .WithTitle($"{playerName}")
                  .AddField($"{item.queueType}", $" {item.tier},{item.elo}", true)
                  .WithThumbnailUrl($"https://ddragon.leagueoflegends.com/cdn/12.23.1/img/profileicon/{player.icon}.png")
                  .Build();

                await ReplyAsync("", false, embed);
            }
            
        }

    }
}
