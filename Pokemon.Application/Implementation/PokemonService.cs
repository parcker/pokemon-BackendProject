using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pokemon.Application.Interface;
using Pokemon.Common.Constants;
using Pokemon.Common.Exception;
using Pokemon.Model;
using Pokemon.ServiceProvider.PokemonProvider;
using Pokemon.ServiceProvider.ShakespeareTranslator;

namespace Pokemon.Application.Implementation
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonApiService _pokemonApiService;
        private readonly IShakespeareTranslatorApiService _shakespeareTranslatorApiService;

        public PokemonService(IPokemonApiService pokemonApiService, IShakespeareTranslatorApiService shakespeareTranslatorApiService)
        {
            _pokemonApiService = pokemonApiService;
            _shakespeareTranslatorApiService = shakespeareTranslatorApiService;
        }
        public async Task<PokemonSpecie> RetrievePokemon(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ApiException(ErrorCodes.NotFound.POKEMON,"Invalid request input a valid pokemon name or id");
                
            }
            var pokemonSpecie = await _pokemonApiService.GetPokemonSepecieAsync(name);
            if(pokemonSpecie is null)
            {
                throw new ApiException(ErrorCodes.NotFound.POKEMON,"Invalid request input a valid pokemon name or id");

            }
            // If this Regex expression is to be use in multiple places i would have used a static method in a static class
            var replacement = Regex.Replace(pokemonSpecie.Description, @"\t|\n|\r", " ");
            
            var translateText = await _shakespeareTranslatorApiService.TranslateToShakespeareanAsync(replacement);
            if (string.IsNullOrEmpty(translateText)) return pokemonSpecie;
            
            pokemonSpecie.Description = translateText;
            return pokemonSpecie;
        }
    }

   
}
