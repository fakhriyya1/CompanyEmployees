using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CompanyEmployees
{
    public class GLobalExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager _logger;

        public GLobalExceptionHandler(ILoggerManager logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            var contextFeature=httpContext.Features.Get<IExceptionHandlerFeature>();
            if(contextFeature != null)
            {
                httpContext.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                _logger.LogError($"Something went wrong: {exception.Message}");

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    Message = contextFeature.Error.Message,
                    StatusCode = httpContext.Response.StatusCode
                }.ToString());
            }

            return true;
        }
    }
}
