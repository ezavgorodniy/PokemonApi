using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class DefaultCacheServiceTest
    {
        private readonly DefaultCacheService _cacheService;

        public DefaultCacheServiceTest()
        {
            _cacheService = new DefaultCacheService();
        }

        [Fact]
        public void GetShouldReturnNull()
        {
            var actualValue = _cacheService.GetValue("any key");

            Assert.Null(actualValue);
        }

        [Fact]
        public void SetShouldNotFail()
        {
            _cacheService.SetValue("some key", "some value");
        }
    }
}
