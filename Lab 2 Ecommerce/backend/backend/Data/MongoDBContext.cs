using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDBConnection");
        var databaseName = "mydatabase"; // Or you can get this value from configuration

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    //public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");
}
