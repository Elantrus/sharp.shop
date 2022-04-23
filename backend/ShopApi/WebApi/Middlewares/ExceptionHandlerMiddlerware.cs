using System.Diagnostics.CodeAnalysis;
using System.Net;
using WebApi.Middlewares.Models;

namespace WebApi.Middlewares;

public class ExceptionHandlerMiddlerware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddlerware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            HandleException(context, environment, ex);
        }
    }

    private void HandleException(HttpContext context, IWebHostEnvironment environment, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        switch (exception.GetType())
        {
            default:
                break;
        }

        context.Response.StatusCode = (int) statusCode;
        
        var responseError = new RequestErrorBase()
        {
            Message = exception.Message,
            Ocurrence = DateTime.Now
        };

        if (environment.IsDevelopment())
            responseError.StackTrace = exception.StackTrace;

        context.Response.WriteAsJsonAsync(responseError);
    }
}