using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pokemon.Core.Configuration;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Pokemon.Core.Wrappers;
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

        [Fact]
        public void PokeApiServiceRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(PokeApiService) &&
                descriptor.ServiceType == typeof(IPokeApiService))), Times.Once);
        }

        [Fact]
        public void PokeApiWrapperRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(PokeApiWrapper) &&
                descriptor.ServiceType == typeof(IPokeApiWrapper))), Times.Once);
        }

        [Fact]
        public void ShakespearenApiWrapperRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(ShakespeareanApiWrapper) &&
                descriptor.ServiceType == typeof(IShakespeareanApiWrapper))), Times.Once);
        }

        [Fact]
        public void ShakespearenApiServiceRegistered()
        {
            _mockServiceCollection.Verify(collection => collection.Add(It.Is<ServiceDescriptor>(descriptor =>
                descriptor.Lifetime == ServiceLifetime.Transient &&
                descriptor.ImplementationType == typeof(ShakespeareanApiService) &&
                descriptor.ServiceType == typeof(IShakespeareanApiService))), Times.Once);
        }
    }
}
