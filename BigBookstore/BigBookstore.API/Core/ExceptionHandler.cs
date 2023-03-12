using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Services;

namespace BigBookstore.API.Core
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly LoggerService _logger;

        // ToDo: inject the logger so that it can be used for logging
        public ExceptionHandler(RequestDelegate next, LoggerService logger)
        {
            this._next = next;
            this._logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                await this._logger.Log(ex.Message, ex.StackTrace);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                //ToDo: Include all Exceptions that are in the system.
                //if (ex is ForbiddenUseCaseExecutionException)
                //{
                //    statusCode = StatusCodes.Status403Forbidden;  
                //}

                if (ex is EntityNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }
                else if (ex is UnprocessableEntityException e)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }
                else if(ex is DbSetNotFoundException e)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }
               else
                {
                    statusCode = StatusCodes.Status500InternalServerError;
                }
                //if (ex is UseCaseConflictException conflictEx)
                //{
                //    statusCode = StatusCodes.Status409Conflict;
                //    response = new { message = conflictEx.Message };
                //}


                httpContext.Response.StatusCode = statusCode;
                if(response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
