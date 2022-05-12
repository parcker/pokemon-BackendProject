namespace Pokemon.Common.Exception
{
    public class ApiException:System.Exception
    {
        public int ErrorCode { get; }
        public string Field { get; }
        
        /// <summary>
        /// Api exception constructor
        /// </summary>
        /// <param name="errorCode">specific code of error</param>
        /// <param name="message">message of error default is "Api Exception"</param>
        /// <param name="field">specific field that occur error default is null</param>
        public ApiException(int errorCode, string message = "Api Exception", string field = null) : base(message)
        {
            ErrorCode = errorCode;
            Field = field;
        }
    }
}