using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Models.lolModels
{
    public class LolPlayerModel
    {
        public string name { get; set; }

        public string icon { get; set; }

        public string puuid { get; set; }

        public List<MatchesModel> matches { get; set; }

        public eloModel elo { get; set; }
    }
}
