using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Models.lolModels
{
    public class MatchesModel
    {
        public string id { get; set; }

        public string champion { get; set; }

        public int kills { get; set; }

        public int deaths { get; set; }

        public int assist { get; set; }
    }
}
