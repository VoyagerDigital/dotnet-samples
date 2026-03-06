namespace LiveTesting.Api.Tests.Tests;

[Collection("EndpointTests")]
public abstract class EndpointTest(EndpointTestWebApplicationFactory factory)
{
    protected HttpClient ApiClient { get; } = factory.ApiClient;
}