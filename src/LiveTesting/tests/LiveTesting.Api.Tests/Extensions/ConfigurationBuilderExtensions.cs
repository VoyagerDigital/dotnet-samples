using Microsoft.Extensions.Configuration;

namespace LiveTesting.Api.Tests.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfiguration GetTestConfiguration(this IConfigurationBuilder builder)
    {
        return builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.development.json", optional: true)
            .Build();
    }
}