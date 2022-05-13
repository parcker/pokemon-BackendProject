using System.Collections.Generic;

namespace Pokemon.Common.ErrorModel
{
    public class ErrorResponse
    {
        public List<Error> Errors { get; set; } = new List<Error>();
    }
}