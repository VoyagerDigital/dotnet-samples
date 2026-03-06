namespace LiveTesting.Options;

public class AzureCommunicationServiceConfiguration : IApplicationConfiguration
{
    public static string Section => "AzureCommunicationService";
    
    public string ConnectionString { get; set; } = null!;
}