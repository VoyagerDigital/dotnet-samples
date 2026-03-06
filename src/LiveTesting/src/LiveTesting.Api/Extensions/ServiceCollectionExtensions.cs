using FastEndpoints;
using FastEndpoints.Swagger;
using LiveTesting.Contexts;
using LiveTesting.Options;
using LiveTesting.Persistence;
using LiveTesting.Services;
using LiveTesting.Services.Email;
using LiveTesting.Services.Email.Strategies;

namespace LiveTesting.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.RegisterFastEndpointsServices()
            .RegisterConfigurations(configuration)
            .RegisterContexts()
            .RegisterDataStores()
            .RegisterExternalServices();
        
        return services;
    }

    private static IServiceCollection RegisterFastEndpointsServices(this IServiceCollection services)
    {
        services.AddFastEndpoints()
            .SwaggerDocument();
        
        return services;
    }

    private static IServiceCollection RegisterDataStores(this IServiceCollection services)
    {
        services.AddSingleton<BookData>();

        return services;
    }
    
    private static IServiceCollection RegisterExternalServices(this IServiceCollection services)
    {
        services.AddScoped<AzureCommunicationStrategy>();
        services.AddScoped<LiveTestingEmailStrategy>();
        services.AddScoped<IEmailStrategySelector, EmailStrategySelector>();
        services.AddScoped<IEmailService, EmailService>();
        
        return services;
    }
    
    private static IServiceCollection RegisterConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AzureCommunicationServiceEmailConfiguration>(configuration.GetSection(AzureCommunicationServiceEmailConfiguration.Section));
        services.Configure<LiveTestingConfiguration>(configuration.GetSection(LiveTestingConfiguration.Section));
        
        return services;
    }
    
    private static IServiceCollection RegisterContexts(this IServiceCollection services)
    {
        services.AddScoped<ILiveTestingContext, LiveTestingContext>();
        
        return services;
    }
}