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

            result.EnsureSuccessStatusCode();

            var content = result.Content.ReadAsStringAsync().Result;

            LolPlayerModel json = JsonConvert.DeserializeObject<LolPlayerModel>(content);

            return json;
        }

        public LolPlayerStats[] GetPlayerRanks(LolPlayerModel player)
        {
            var result = _httpClient.GetAsync($"https://br1.api.riotgames.com/lol/league/v4/entries/by-summoner/{player.id}").Result;

            result.EnsureSuccessStatusCode();

            var content = result.Content.ReadAsStringAsync().Result;

            LolPlayerStats[] stats = JsonConvert.DeserializeObject<LolPlayerStats[]>(content);

            return stats; 
        }
    }
}
