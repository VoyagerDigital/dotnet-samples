using LiveTesting.Options;

namespace LiveTesting.Api.Tests.Configurations;

public class TestConfiguration : IApplicationConfiguration
{
    public static string Section => "Testing";

    public Uri Uri { get; set; } = null!;
    public string Type { get; set; } = null!;
}