using System;
namespace Pokemon.Common.Exception
{
    public class ApiError
    {
        /// <summary>
        /// specific code of error
        /// </summary>
        public int ErrorCode { get; set; }
       
        public string Message { get; set; }
    }
}
