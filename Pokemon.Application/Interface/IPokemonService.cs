using System;
using System.Threading.Tasks;
using Pokemon.Common.BaseResponse;
using Pokemon.Model;

namespace Pokemon.Application.Interface
{
    public interface IPokemonService
    {
        Task<PokemonSpecie> RetrievePokemon(string name);
    }
}
