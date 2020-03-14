namespace Pokemon.Core.Interfaces
{
    public interface IPokemonConfiguration
    {
        string ShakespeareanApiUrl { get; }

        string PokeApiBaseUrl { get; }
    }
}
