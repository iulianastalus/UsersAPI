namespace Users.ApplicationCore.ValueObjects;

public class DbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
    public string EventsCollectionName { get; set; }
}
