using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Models.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IRestClient restClient;

        public PokemonRepository()
        {
            restClient = new RestClient("https://pokeapi.co/api/v2/");
        }
        public async Task<Pokemon?> GetPokemon(string name, CancellationToken cancellationToken)
        {
            var request = new RestRequest(string.Format("pokemon/{0}", name), Method.Get);
            var response = await restClient.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                return null;
            }

            var pokemonData = JsonConvert.DeserializeObject<PokemonApiResponse>(response.Content ?? "");

            return new Pokemon
            {
                Id = pokemonData?.Id,
                Name = pokemonData?.Name,
                Order = pokemonData?.Order,
                Stats = pokemonData?.Stats?.Select(stat =>
                new PokemonStat
                {
                    BaseStat = stat.BaseStat,
                    Name = stat?.Stat?.Name
                }).ToList(),
                Weight = pokemonData?.Weight,
                Types = pokemonData?.Types?.Select(type => type?.Type?.Name).ToList()
            };
        }
    }
}