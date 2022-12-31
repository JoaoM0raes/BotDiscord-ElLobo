using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Models.lolModels
{
    public class LolPlayerStats
    {
        [JsonProperty("summonerName")]
        public string name { get; set; }
        
        [JsonProperty("rank")]
        public string elo { get; set; }

        [JsonProperty("tier")]
        public string tier { get; set; }

        [JsonProperty("queueType")]
        public string queueType { get; set; }

        public List<MatchesModel> matches { get; set; }
    }
}
