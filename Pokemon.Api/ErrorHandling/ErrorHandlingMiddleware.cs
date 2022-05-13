using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pokemon.Common.BaseResponse;
using Pokemon.Common.ErrorModel;
using Pokemon.Common.Exception;
using Pokemon.Common.Extentions;

namespace Pokemon.Api.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        /// <summary>
        /// Constructor for <see cref="ErrorHandlingMiddleware"/>
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //log the error
                _logger.LogError($"Something went wrong." +
                                 $"\n Exception: {ex}" +
                                 $"\n Message: {ex.Message}" +
                                 $"\n StackTrace: {ex.StackTrace}");

                //handle the exception
                await HandleExceptionAsync(context, ex, env);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        { 
            ErrorResponse errorResponse;
            var stackTrace = string.Empty;
            var response = context.Response;
            switch (exception)
            {
                case var _ when exception is ArgumentIsNullException argumentIsNullException:
                    // argumentIsNullException error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse = argumentIsNullException.ChangeToError();
                    break;
                case var _ when exception is NotFoundException notFoundException:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse = notFoundException.ChangeToError();
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = exception.ChangeToError();
                    if (env.IsEnvironment("Development"))
                    {
                        stackTrace = exception.StackTrace;
                    }
                    break;
            }
            var error = Result.Fail(errorResponse.Errors,
                string.IsNullOrEmpty(exception.Message) ? "Error occured" : exception.Message,
                response.StatusCode.ToString());

            var result = JsonSerializer.Serialize(error);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = response.StatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}