using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Models.lolModels
{
    public class LolPlayerModel
    {       

        [JsonProperty ("profileIconId")]
        public string icon { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        public LolPlayerStats[] stats; 
    }
}
