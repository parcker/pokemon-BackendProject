using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Api.Cache;
using Pokemon.Application.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace Pokemon.Api.Controllers
{
    [Route("[controller]")]
    public class PokemonController : BaseController
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        
        [SwaggerOperation(OperationId = "get-pokemon", Summary = "Pokemon name and description")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Cached(600)]
        public async Task<IActionResult> Get([FromQuery] string name)
        {

            var pokemon= await _pokemonService.RetrievePokemon(name);
            return Ok(pokemon);
        }
    }
}
