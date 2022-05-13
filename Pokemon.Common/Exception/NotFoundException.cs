using System;
namespace Pokemon.Common.Exception
{
    public class NotFoundException: System.Exception
    {
        public string Code { get; set; }
        public NotFoundException()
        { }

        public NotFoundException(string message, string code="Notfound")
            : base(message)
        {
            Code = code;
        }

        public NotFoundException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}