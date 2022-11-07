using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetTaskGetFront.Web.Infrastracture.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var details = ex switch
            {
                ValidationException validationException => GetValidationExceptionProblemDetails(validationException),
                _ => GetUnknownExceptionDetails(ex)
            };

            var serializedBody = JsonSerializer.Serialize(details, details.GetType(), new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(serializedBody);
        }

        private ProblemDetails GetValidationExceptionProblemDetails(ValidationException ex)
        {
            var errors = ex.Errors.GroupBy(x => x.PropertyName)
                .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).ToArray());
            return new ValidationProblemDetails(errors)
            {
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            };
        }

        private ProblemDetails GetUnknownExceptionDetails(Exception ex) => new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Detail = ex.Message
        };
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
