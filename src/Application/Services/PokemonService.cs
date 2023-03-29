public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        this.pokemonRepository = pokemonRepository;
    }
    public async Task<PokemonDto> GetPokemon(string name, CancellationToken cancellationToken)
    {
        var pokemon = await pokemonRepository.GetPokemon(name, cancellationToken);

        return new PokemonDto
        {
            Id = pokemon?.Id,
            Name = pokemon?.Name,
            Order = pokemon?.Order,
            Stats = CreateStatsDictionary(pokemon?.Stats),
            Types = pokemon?.Types,
            Weight = pokemon?.Weight
        };
    }

    private Dictionary<string, int?>? CreateStatsDictionary(IList<PokemonStat>? statsList)
    {
        if(statsList is null || !statsList.Any())
            return null;

        var statsDictionary = new Dictionary<string, int?>();

        foreach(var stat in statsList)
        {
            if(stat?.Name is not null)
                statsDictionary.Add(stat.Name, stat?.BaseStat);
        }

        return statsDictionary;
    }
}