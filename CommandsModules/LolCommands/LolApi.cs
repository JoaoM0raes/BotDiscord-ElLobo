using BotDiscord.Models.lolModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace BotDiscord.CommandsModules.LolCommands
{
    public class LolApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public LolApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("RiotApi");
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-d4a99e72-e1fd-41dd-a030-8359bfae0f3c");
        }

        public LolPlayerModel GetPlayerId(string SummonnerName)
        {
            var result = _httpClient.GetAsync($"//br1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{SummonnerName}").Result;

            var content = result.Content.ReadAsStringAsync().Result;

            result.EnsureSuccessStatusCode();

            LolPlayerModel json = JsonConvert.DeserializeObject<LolPlayerModel>(content);

            return json;
        }

        public LolPlayerStats GetPlayerRanks(LolPlayerModel player)
        {

        }
    }
}
