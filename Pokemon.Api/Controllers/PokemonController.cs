using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Api.Cache;
using Pokemon.Application.Interface;
using Pokemon.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController : BaseController
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)=>  _pokemonService = pokemonService;
        
        
        [SwaggerOperation(OperationId = "get-pokemon", Summary = "Pokemon name and description")]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PokemonSpecie))]
        [Cached(60)]
        
        public async Task<IActionResult> Get([FromRoute]string name)
        {

            var pokemon= await _pokemonService.RetrievePokemon(name);
            return Ok(pokemon);
        }
    }
}
