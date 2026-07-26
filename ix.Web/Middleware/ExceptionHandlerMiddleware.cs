using System.Net;
using System.Text.Json;

namespace ix.Web.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate _next) 
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpResponse response = context.Response;
        response.ContentType = "application/json";
        int statusCode;
        string title;

        switch (ex)
        {
            case ArgumentException:
                statusCode = (int)HttpStatusCode.BadRequest;
                title = "Ошибка входных данных";
                break;
            case InvalidOperationException:
                statusCode = (int)HttpStatusCode.Conflict;
                title = "Ошибка операции";
                break;
            case UnauthorizedAccessException:
                statusCode = (int)HttpStatusCode.Unauthorized;
                title = "Ошибка авторизации";
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                title = "Ошибка не определена";
                break;
        }

        response.StatusCode = statusCode;
        var result = new
        {
            title,
            detail = ex.Message,
            status = statusCode
        };

        await response.WriteAsync(JsonSerializer.Serialize(result));
    }
}