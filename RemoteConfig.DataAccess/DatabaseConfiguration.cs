namespace RemoteConfig.DataAccess;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; }
    public bool UseInMemoryDatabase { get; set; }
}