using Mongo_Docker_API;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>
{
    string connectionString = "mongodb://admin:pass@mongo:27017/";
    var client = new MongoClient(connectionString);
    var database = client.GetDatabase("MySuperiorDB");
    var collection = database.GetCollection<People>("People");

    var people = await collection.Find<People>(_ => true).ToListAsync();
    return people;
});


app.Run();
