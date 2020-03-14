namespace Pokemon.Core.Interfaces
{
    public interface IPokemonConfiguration
    {
        string ShakespeareanApiUrl { get; }

        string ShakespeareanApiSecret { get; }

        string PokeApiBaseUrl { get; }
    }
}
