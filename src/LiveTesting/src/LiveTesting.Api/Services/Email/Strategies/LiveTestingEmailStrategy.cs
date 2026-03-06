namespace LiveTesting.Services.Email.Strategies;

public sealed class LiveTestingEmailStrategy : IEmailStrategy
{
    public Task SendAsync(string to,
        string subject,
        string body,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}