using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Infra.FileConfigs
{
    public class FileConfig
    {
        public string Token { get; set; }

        public FileConfig()
        {
            Token = ConfigurationManager.AppSettings["token"];
        }

    }
}
