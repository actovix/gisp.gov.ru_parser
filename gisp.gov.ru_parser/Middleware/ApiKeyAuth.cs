using Microsoft.Extensions.Options;
using gisp.gov.ru_parser.Models.AuthModels;
using gisp.gov.ru_parser.Models.Configs;

namespace gisp.gov.ru_parser.Middleware;

public class ApiKeyAuth
{
    private readonly RequestDelegate _next;
    private readonly Dictionary<string, ApiKeys> _keys;

    public ApiKeyAuth(RequestDelegate next, IOptions<ApiKeysStorage> keys)
    {
        _next = next;
        _keys = keys.Value.Keys;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var req = context.Request;

        req.EnableBuffering();

        if (req.Method == HttpMethods.Post)
        {
            var keys = await req.ReadFromJsonAsync<ApiKeys>();

            if (!req.HasJsonContentType() || string.IsNullOrEmpty(keys?.App.AppSecret.ToString()))
            {
                await GetResponse(context, 401, "Api keys missing");
                return;
            }

            var ctr = context.Request.RouteValues["controller"] as string ?? "";
            if (!_keys.ContainsKey(ctr) || !_keys[ctr].IsEqual(keys))
            {
                await GetResponse(context, 403, "Invalid api keys");
                return;
            };

        }

        req.Body.Position = 0;
        await _next(context);
    }

    private async Task GetResponse(HttpContext context, int code, string message)
    {
        context.Response.StatusCode = code;
        await context.Response.WriteAsync(message);
    }
}
