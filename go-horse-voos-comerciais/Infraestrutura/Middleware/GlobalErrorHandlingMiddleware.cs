using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using System.Net;
using System.Text.Json;

namespace go_horse_voos_comerciais.Infraestrutura.Middleware;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync (HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        } catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode;
        string mensagem;
        var exceptionType = ex.GetType();

        if (exceptionType == typeof(GhvcValidacaoException))
        {
            mensagem = "Erro: " + ex.Message;
            statusCode = HttpStatusCode.BadRequest;
        } else
        {
            mensagem = ex.Message;
            statusCode = HttpStatusCode.InternalServerError;
        }

        var response = JsonSerializer.Serialize(new { statusCode, mensagem});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) statusCode;
        return context.Response.WriteAsync(response);
    }
}
