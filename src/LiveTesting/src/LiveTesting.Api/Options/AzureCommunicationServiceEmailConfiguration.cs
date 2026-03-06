namespace LiveTesting.Options;

public sealed class AzureCommunicationServiceEmailConfiguration : AzureCommunicationServiceConfiguration
{
    public new static string Section => $"{AzureCommunicationServiceConfiguration.Section}:Email";
    
    public string SenderAddress { get; set; } = null!;
}