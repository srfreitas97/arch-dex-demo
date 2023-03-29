public interface IPokemonService
{
    Task<PokemonDto> GetPokemon(string name, CancellationToken cancellationToken);
}