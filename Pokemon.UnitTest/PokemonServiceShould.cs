using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Pokemon.Application.Implementation;
using Pokemon.Common.Exception;
using Pokemon.Model;
using Pokemon.ServiceProvider.PokemonProvider;
using Pokemon.ServiceProvider.ShakespeareTranslator;
using Xunit;

namespace Pokemon.UnitTest
{
    
    public class PokemonServiceShould
    {
        Mock<IPokemonApiService> _pokemonApiService;
        Mock<IShakespeareTranslatorApiService> _shakespeareTranslatorApiService;
        private PokemonService _pokemonService;
        public PokemonServiceShould()
        {
            _pokemonApiService = new Mock<IPokemonApiService>();
            _shakespeareTranslatorApiService = new Mock<IShakespeareTranslatorApiService>();
            _pokemonService = new PokemonService(_pokemonApiService.Object, _shakespeareTranslatorApiService.Object);
        }
        [Fact]
        public async Task Throw_Exception_Giving_Name_is_Null()
        {
            //Arrange
            var name = string.Empty;
            //Act
            var result =await Assert.ThrowsAsync<ApiException>( () =>  _pokemonService.RetrievePokemon(name));
            //Assert
            result.Message.Should().Be("Invalid request input a valid pokemon name or id");
        }
        [Fact]
        public async Task Test_That_PokemonSpecie_Throws_Exception_Giving_Name_Does_Not_Exist()
        {
            //Arrange
            var name = "JohnDeo";
            PokemonSpecie pokemonSpecie = null;
            _pokemonApiService.Setup(x => x.GetPokemonSepecieAsync(It.IsAny<string>())).ReturnsAsync(pokemonSpecie);
                
            //Act
            var result = await Assert.ThrowsAsync<ApiException>( () =>  _pokemonService.RetrievePokemon(name));
            //Assert
            result.Message.Should().Be("Invalid request input a valid pokemon name or id");
        }
        [Fact]
        public async Task Test_That_PokemonSpecie_Exist_But_Translation_ToShakespearean_Returns_Empty()
        {
            //Arrange
            var name = "ditto";
            var pokemonSpecie = new PokemonSpecie()
            {
                Name = "ditto",
                Description = "this is my message"
            };
            _pokemonApiService.Setup(x => x.GetPokemonSepecieAsync(It.IsAny<string>())).ReturnsAsync(pokemonSpecie);
            
            _shakespeareTranslatorApiService.Setup(x => x.TranslateToShakespeareanAsync(It.IsAny<string>()))
                .ReturnsAsync(String.Empty);
                
            //Act
            var result = await _pokemonService.RetrievePokemon(name);
            //Assert
            result.Description.Should().Be("this is my message");
        }
    }
}
