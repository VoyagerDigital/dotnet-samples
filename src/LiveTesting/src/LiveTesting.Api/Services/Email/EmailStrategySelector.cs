using LiveTesting.Contexts;

namespace LiveTesting.Services.Email.Strategies;

public interface IEmailStrategySelector
{
    public IEmailStrategy SelectStrategy();
}

public sealed class EmailStrategySelector(ILiveTestingContext testCtx,
    AzureCommunicationStrategy azureCommunicationStrategy,
    LiveTestingEmailStrategy testingStrategy) : IEmailStrategySelector
{
    public IEmailStrategy SelectStrategy()
    {
        return testCtx.SuppressExternalSideEffects
            ? testingStrategy
            : azureCommunicationStrategy;
    }
}