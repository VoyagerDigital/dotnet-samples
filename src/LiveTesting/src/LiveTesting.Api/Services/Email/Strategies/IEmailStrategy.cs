namespace LiveTesting.Services.Email.Strategies;

public interface IEmailStrategy
{
    public Task SendAsync(string to,
        string subject,
        string body,
        CancellationToken cancellationToken);
}