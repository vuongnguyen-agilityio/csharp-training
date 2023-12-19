using Application.Exceptions;
using Domain.Carts;
using Domain.Products;
using Domain.Profiles;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(
            ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ValidationException validationException)
            {
                _logger.LogError(
                    exception,
                    "Exception occurred: {Message} {@Errors} {@Exception}",
                    exception.Message,
                    validationException.Errors,
                    validationException);
            }
            else
            {
                _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
            }

            var exceptionDetails = GetExceptionDetails(exception);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
            };

            if (exceptionDetails.Errors is not null)
            {
                problemDetails.Extensions["errors"] = exceptionDetails.Errors;
            }

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation error",
                    "One or more validation errors has occurred",
                    validationException.Errors),
                UnauthorizedAccessException => new ExceptionDetails(
                    StatusCodes.Status401Unauthorized,
                    "Unauthorized",
                    "Unauthorized Error",
                    "Unauthorized",
                    null),
                ProductNotFoundException productNotFoundException => new ExceptionDetails(
                    StatusCodes.Status404NotFound,
                    "NotFound",
                    "Product not found",
                    productNotFoundException.Message,
                    null
                    ),
                CartNotFoundException cartNotFoundException => new ExceptionDetails(
                    StatusCodes.Status404NotFound,
                    "NotFound",
                    "Cart not found",
                    cartNotFoundException.Message,
                    null
                    ),
                ProfileNotFoundException profileNotFoundException => new ExceptionDetails(
                    StatusCodes.Status404NotFound,
                    "NotFound",
                    "Profile not found",
                    profileNotFoundException.Message,
                    null
                    ),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    "An unexpected error has occurred",
                    null)
            };
        }

        internal record ExceptionDetails(
            int Status,
            string Type,
            string Title,
            string Detail,
            IEnumerable<object>? Errors);
    }
}
