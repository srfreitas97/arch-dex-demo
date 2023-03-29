namespace Application.Models
{
    public class PokemonDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Order { get; set; }
        public decimal? Weight { get; set; }
        public Dictionary<string, int?>? Stats { get; set; }
        public IList<string?>? Types { get; set; }
    }
}