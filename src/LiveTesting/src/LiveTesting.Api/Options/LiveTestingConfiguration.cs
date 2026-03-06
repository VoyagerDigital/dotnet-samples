namespace LiveTesting.Options;

public sealed class LiveTestingConfiguration : IApplicationConfiguration
{
    public static string Section => "Testing:Live";
    
    public string MarkerHeader { get; set; }
    public string KeyHeader { get; set; }
    public string TestKey { get; set; }
}