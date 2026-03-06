using LiveTesting.Api.Tests.Configurations;
using LiveTesting.Api.Tests.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace LiveTesting.Api.Tests;

public sealed class EndpointTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private TestConfiguration? _testConfiguration;
    public HttpClient ApiClient { get; private set; } = null!;
    
    public Task InitializeAsync()
    {
        _testConfiguration = new ConfigurationBuilder()
            .GetTestConfiguration()
            .GetSection(TestConfiguration.Section)
            .Get<TestConfiguration>();
        
        if (_testConfiguration is null)
            throw new InvalidOperationException("TestConfiguration is null");
        
        ConfigureHttpClient();
        
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        ApiClient.Dispose();
        
        await base.DisposeAsync();
    }

    private void ConfigureHttpClient()
    {
        ApiClient = CreateClient();
        ApiClient.BaseAddress = _testConfiguration!.Uri;

        if (_testConfiguration!.Type == "Live")
        {
            ApiClient.DefaultRequestHeaders
                .Add("X-LIVETEST", "true");
            
            ApiClient.DefaultRequestHeaders
                .Add("X-LIVETEST-KEY", "livetesting123");
        }
        
    }
}