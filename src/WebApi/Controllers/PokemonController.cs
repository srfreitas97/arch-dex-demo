using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("pokemon")]
public class PokemonController : ControllerBase
{
    [HttpGet("{name}")]
    public async Task<IActionResult> GetPokemonByName(string name, CancellationToken cancellationToken)
    {
        return Ok("teste");
    }
}