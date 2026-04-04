using BackendRESTfulWebAPI.Exceptions;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DestinationNotFoundException ex)
        {
            await Handle(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            await Handle(context, HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    private static async Task Handle(HttpContext context, HttpStatusCode code, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var result = new
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}