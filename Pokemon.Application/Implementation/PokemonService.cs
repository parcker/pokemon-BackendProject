using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pokemon.Application.Interface;
using Pokemon.Common.BaseResponse;
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
                throw new ArgumentIsNullException(ErrorCodes.NotFound.POKEMON,"Invalid request input a valid pokemon name or id");
                
            }
            var pokemonSpecie = await _pokemonApiService.GetPokemonSepecieAsync(name);
            if(pokemonSpecie is null)
            {
                throw new ArgumentIsNullException(ErrorCodes.NotFound.POKEMON,"Invalid request input a valid pokemon name or id");

            }
           
            var replacement = Regex.Replace(pokemonSpecie.Description, @"\t|\n|\r|\f", " ");
            
            var translateText = await _shakespeareTranslatorApiService.TranslateToShakespeareanAsync(replacement);
            if (string.IsNullOrEmpty(translateText)) return pokemonSpecie;
            
            pokemonSpecie.Description = translateText;
            return pokemonSpecie;
        }
    }

   
}
