using DalilAcademy.Core.Exceptions;

using FluentValidation;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Middleware;

public class GlobalExceptionHandler(
    IProblemDetailsService problemDetails,
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context, Exception exception, CancellationToken ct)
    {
        var (status, title) = exception switch
        {
            ValidationException => (400, "Validation failed"),
            NotFoundException or KeyNotFoundException => (404, "Resource not found"),
            ConflictException => (409, "Conflict"),
            UnauthorizedAccessException => (401, "Unauthorized"),
            ArgumentException => (400, "Bad Request"),
            InvalidFileException => (400, "Invalid File"),
            _ => (500, "An unexpected error occurred")
        };
        if (status == 500) logger.LogError(exception, "Unhandled exception");
        context.Response.StatusCode = status;
        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = status != 500 && exception is not ValidationException ? exception.Message : null
        };
        if (exception is ValidationException ve)
            problem.Extensions["errors"] = ve.Errors.GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
        return await problemDetails.TryWriteAsync(new() { HttpContext = context, ProblemDetails = problem });
    }
}