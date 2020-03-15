using System.Collections.Concurrent;
using Pokemon.Core.Interfaces;

namespace Pokemon.Api.Cache
{
    public class InMemoryPokemonCacheService : ICacheService
    {
        private static readonly ConcurrentDictionary<string, string> Cache = new ConcurrentDictionary<string, string>();

        public string GetValue(string key)
        {
            return Cache.TryGetValue(key, out var result) ? result : null;
        }

        public void SetValue(string key, string value)
        {
            Cache.TryAdd(key, value);
        }
    }
}
