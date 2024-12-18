using System.Net;
using Domain.exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Application.v1.Shared.Exception;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
    {
        var exceptionResponse = exception switch
        {
            NotFoundObjectException _ => new ExceptionResponse(HttpStatusCode.NotFound, exception.Message), // 404
            NotGoodLoginException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message), // 400
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, exception.Message) // 500
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exceptionResponse.HttpStatusCode;

        var jsonResponse = JsonConvert.SerializeObject(exceptionResponse);
        await context.Response.WriteAsync(jsonResponse);
    }

    private record ExceptionResponse(HttpStatusCode HttpStatusCode, string Description);
}