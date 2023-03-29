using Application.Models;

namespace Application.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonDto> GetPokemon(string name, CancellationToken cancellationToken);
    }
}