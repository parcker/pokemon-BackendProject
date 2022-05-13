using Pokemon.Common.ErrorModel;
using Pokemon.Common.Exception;

namespace Pokemon.Common.Extentions
{
    public static class ErrorResponseExtension
    {
        public static ErrorResponse ChangeToError(this System.Exception exception)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Errors.Add(new Error
            {
                Code = "SYSTEM_ERROR",
                Message = "Unexpected error occured please try again or confirm current operation status"
            });
            return errorResponse;
        }
        public static ErrorResponse ChangeToError(this ArgumentIsNullException exception)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Errors.Add(new Error
            {
                Code = "SYSTEM_ERROR",
                Message = "Unexpected error occured please try again or confirm current operation status"
            });
            return errorResponse;
        }
    }
}