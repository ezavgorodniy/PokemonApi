using Pokemon.Api.Cache;
using Xunit;

namespace Pokemon.Api.Tests.CacheTests
{
    public class InMemoryPokemonCacheServiceTests
    {
        private readonly InMemoryPokemonCacheService _cacheService;

        public InMemoryPokemonCacheServiceTests()
        {
            _cacheService = new InMemoryPokemonCacheService();
        }

        [Fact]
        public void ByDefaultReturnNull()
        {
            var actualValue = _cacheService.GetValue("someKey");

            Assert.Null(actualValue);
        }

        [Fact]
        public void ReturnSetValueOnGet()
        {
            const string expectedKey = "expectedKey";

            var actualValueBeforeSet = _cacheService.GetValue(expectedKey);
            Assert.Null(actualValueBeforeSet);

            const string expectedValue = "expectedValue";
            _cacheService.SetValue(expectedKey, expectedValue);

            var actualValueAfterSet = _cacheService.GetValue(expectedKey);
            Assert.Equal(expectedValue, actualValueAfterSet);
        }
    }
}
