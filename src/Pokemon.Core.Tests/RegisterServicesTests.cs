using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pokemon.Core.Configuration;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests
{
    public class RegisterServicesTests
    {
        private readonly Mock<IServiceCollection> _mockServiceCollection;

        public RegisterServicesTests()
        {
            _mockServiceCollection = new Mock<IServiceCollection>();
            RegisterServices.ConfigureServices(_mockServiceCollection.Object);
        }

        [Fact]
        public void PokemonConfigurationRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(PokemonConfiguration) &&
                descriptor.ServiceType == typeof(IPokemonConfiguration))), Times.Once);
        }

        [Fact]
        public void PokemonDescriptionServiceRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(PokemonDescriptionService) &&
                descriptor.ServiceType == typeof(IPokemonDescriptionService))), Times.Once);
        }
    }
}
