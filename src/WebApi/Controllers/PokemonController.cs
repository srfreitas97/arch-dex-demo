using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("pokemon")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        this.pokemonService = pokemonService;
    }
    [HttpGet("{name}")]
    public async Task<IActionResult> GetPokemonByName(string name, CancellationToken cancellationToken)
    {
        var pokemon = await pokemonService.GetPokemon(name, cancellationToken);
        if(pokemon is null)
            return NoContent();

        return Ok(pokemon);
    }
}