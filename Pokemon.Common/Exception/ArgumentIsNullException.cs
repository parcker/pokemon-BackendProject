namespace Pokemon.Common.Exception
{
    public class ArgumentIsNullException:System.Exception
    {
        public int ErrorCode { get; }
        public string Field { get; }

        public ArgumentIsNullException()
        {
            
        }
        /// <summary>
        /// Api exception constructor
        /// </summary>
        /// <param name="errorCode">specific code of error</param>
        /// <param name="message">message of error default is "Api Exception"</param>
        /// <param name="field">specific field that occur error default is null</param>
        public ArgumentIsNullException(int errorCode, string message, string field = null) : base(message)
        {
            ErrorCode = errorCode;
            Field = field;
        }
        public ArgumentIsNullException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}