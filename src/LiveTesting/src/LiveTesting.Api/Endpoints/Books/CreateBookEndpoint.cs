using FastEndpoints;
using LiveTesting.Domain.Books;
using LiveTesting.Persistence;
using LiveTesting.Services;
using LiveTesting.Services.Email;

namespace LiveTesting.Endpoints.Books;

public sealed class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
}

public sealed class CreateBookResponse
{
    public int Id { get; set; }
}

public sealed class CreateBookEndpoint(BookData dataStore,
    IEmailService emailService) : Endpoint<CreateBookRequest, CreateBookResponse>
{
    public override void Configure()
    {
        Post("/book");
        Version(0);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest req,
        CancellationToken ct)
    {
        Book book = new()
        {
            Title = req.Title,
            Author = req.Author
        };
        
        dataStore.Add(book);

        await emailService.SendAsync("test@outlook.com",
            "Book Created",
            $"Book created: {book.Title} by {book.Author}",
            ct);
        
        await Send.OkAsync(new CreateBookResponse { Id =  book.Id },
            cancellation: ct);
    }
}