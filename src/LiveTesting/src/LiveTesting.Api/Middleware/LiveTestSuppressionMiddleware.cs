using LiveTesting.Contexts;
using LiveTesting.Options;
using Microsoft.Extensions.Options;

namespace LiveTesting.Middleware;

public sealed class LiveTestSuppressionMiddleware(RequestDelegate next,
    IOptionsMonitor<LiveTestingConfiguration> liveTestingConfiguration)
{
    public async Task InvokeAsync(HttpContext ctx,
        ILiveTestingContext testCtx)
    {
        var isLiveTest = ctx.Request.Headers.ContainsKey(liveTestingConfiguration.CurrentValue.MarkerHeader);

        if (!isLiveTest)
        {
            await next(ctx);
            return;
        }
        
        if (!ctx.Request.Headers.TryGetValue(liveTestingConfiguration.CurrentValue.KeyHeader, out var providedKey) ||
            string.IsNullOrEmpty(providedKey))
        {
            ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await ctx.Response.WriteAsync("Missing live test key header.");
            return;
        }

        if (providedKey != liveTestingConfiguration.CurrentValue.TestKey)
        {
            ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
            await ctx.Response.WriteAsync("Invalid live test key.");
            return;
        }
        
        testCtx.Suppress();
        
        await next(ctx);
    }
}