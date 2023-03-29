using Newtonsoft.Json;

namespace Infrastructure.Models.Responses
{
    public class PokemonApiResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Order { get; set; }
        public string? Height { get; set; }
        public decimal? Weight { get; set; }
        public IList<PokemonApiStatResponse>? Stats { get; set; }
        public IList<PokemonApiTypeResponse>? Types { get; set; }
    }

    public class PokemonApiStatResponse
    {
        public int? Effort { get; set; }
        [JsonProperty("base_stat")]
        public int? BaseStat { get; set; }
        public PokemonApiStatDataResponse? Stat { get; set; }
    }

    public class PokemonApiStatDataResponse
    {
        public string? Name { get; set; }
        public Uri? Url { get; set; }
    }

    public class PokemonApiTypeResponse
    {
        public int? Slot { get; set; }
        public PokemonApiTypeDataResponse? Type { get; set; }
    }

    public class PokemonApiTypeDataResponse
    {
        public string? Name { get; set; }
        public Uri? Url { get; set; }
    }
}