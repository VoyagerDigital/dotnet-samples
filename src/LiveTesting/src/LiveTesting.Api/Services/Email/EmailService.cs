using LiveTesting.Services.Email.Strategies;

namespace LiveTesting.Services.Email;

public interface IEmailService
{
    public Task SendAsync(string to,
        string subject,
        string body,
        CancellationToken cancellationToken);
}

public sealed class EmailService(IEmailStrategySelector selector) : IEmailService
{
    public async Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken)
    {
        IEmailStrategy selectedStrategy = selector.SelectStrategy();
        await selectedStrategy.SendAsync(to,
            subject,
            body,
            cancellationToken);
    }
}