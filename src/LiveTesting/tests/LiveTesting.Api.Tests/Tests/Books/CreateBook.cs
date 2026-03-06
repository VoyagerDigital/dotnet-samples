using System.Net;
using System.Net.Http.Json;
using LiveTesting.Endpoints.Books;
using Shouldly;

namespace LiveTesting.Api.Tests.Tests.Books;

public sealed class CreateBook(EndpointTestWebApplicationFactory factory) : EndpointTest(factory)
{
    [Fact]
    public async Task Should_Create_Book()
    {
        // Arrange
        var book = new CreateBookRequest()
        {
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald"
        };

        // Act
        HttpResponseMessage httpResponse = await ApiClient.PostAsJsonAsync("/api/book", 
            book);
        
        CreateBookResponse? bookResponse = await httpResponse.Content
            .ReadFromJsonAsync<CreateBookResponse>();

        // Assert
        httpResponse.StatusCode
            .ShouldBe(HttpStatusCode.OK);
        
        bookResponse.ShouldNotBeNull();
        bookResponse.Id
            .ShouldBeGreaterThan(0);
    }
}