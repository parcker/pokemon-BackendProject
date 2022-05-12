using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Common.Exception;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BaseController: ControllerBase
    {
        
    }
}
