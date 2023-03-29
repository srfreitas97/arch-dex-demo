namespace Domain.Entities
{
    public class Pokemon
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Order { get; set; }
        public decimal? Weight { get; set; }
        public IList<PokemonStat>? Stats { get; set; }
        public IList<string?>? Types { get; set; }
    }

    public class PokemonStat
    {
        public string? Name { get; set; }
        public int? BaseStat { get; set; }
    }
}