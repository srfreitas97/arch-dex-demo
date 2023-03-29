public interface IPokemonRepository
{
    public Task<Pokemon?> GetPokemon(string name, CancellationToken cancellationToken);
}