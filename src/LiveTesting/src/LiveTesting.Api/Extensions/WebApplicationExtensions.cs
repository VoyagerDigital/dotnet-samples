using FastEndpoints;
using FastEndpoints.Swagger;
using LiveTesting.Middleware;

namespace LiveTesting.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseMiddleware<LiveTestSuppressionMiddleware>();
        
        app.ConfigureFastEndpoints();
        
        return app;
    }
    
    private static WebApplication ConfigureFastEndpoints(this WebApplication app)
    {
        app.UseFastEndpoints(config =>
        {
            config.Endpoints.RoutePrefix = "api";
            config.Versioning.Prefix = "v";
            config.Versioning.PrependToRoute = true;
        })
        .UseSwaggerGen();

        return app;
    }

    private static WebApplication ConfigureHttps(this WebApplication app)
    {
        app.UseHttpsRedirection();

        return app;
    }
}