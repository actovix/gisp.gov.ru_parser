using System.Net;

namespace gisp.gov.ru_parser.Middleware;

public class TimeoutMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;

    public TimeoutMiddleware(RequestDelegate next, Serilog.ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var cToken = new CancellationTokenSource();

        try
        {
            cToken.CancelAfter(TimeSpan.FromSeconds(15));
            context.RequestAborted = cToken.Token;

            await _next(context);
        }
        catch (OperationCanceledException ex)
        {
            _logger.Error(ex.Message);

            var response = $"System.Net.HttpStatusCode.GatewayTimeout, The time to complete the request has been exceeded.";

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
            await context.Response.WriteAsJsonAsync(response);
        }
        finally
        {
            cToken.Dispose();
        }
    }
}
