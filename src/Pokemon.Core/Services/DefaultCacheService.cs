using Pokemon.Core.Interfaces;

namespace Pokemon.Core.Services
{
    public class DefaultCacheService : ICacheService
    {
        public string GetValue(string key)
        {
            // do nothing with caching by default
            return null;
        }

        public void SetValue(string key, string value)
        {
            // do nothing with caching by default
        }
    }
}
