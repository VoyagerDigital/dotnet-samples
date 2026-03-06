namespace LiveTesting.Contexts;

public interface ILiveTestingContext
{
    public bool SuppressExternalSideEffects { get; }
    public void Suppress();
}

public sealed class LiveTestingContext : ILiveTestingContext
{
    public bool SuppressExternalSideEffects { get; private set; }
    
    public void Suppress() => SuppressExternalSideEffects = true;
}