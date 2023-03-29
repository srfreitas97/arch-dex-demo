using Newtonsoft.Json;

public class PokemonApiResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }

    public string? Order { get; set; }
    public string? Height { get; set; }
    public decimal? Weight { get; set; }
    public IList<PokemonApiStat>? Stats { get; set; }
    public IList<PokemonApiType>? Types { get; set; }
}

public class PokemonApiStat
{
    public int? Effort { get; set; }
    [JsonProperty("base_stat")]
    public int? BaseStat { get; set; }
    public PokemonApiStatData? Stat { get; set; }
}

public class PokemonApiStatData
{
    public string? Name { get; set; }
    public Uri? Url { get; set; }
}

public class PokemonApiType
{
    public int? Slot { get; set; }
    public PokemonApiTypeData? Type { get; set; }
}

public class PokemonApiTypeData
{
    public string? Name { get; set; }
    public Uri? Url { get; set; }
}