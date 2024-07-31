using Mongo_Docker_API;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddMongoDBClient("mongo");

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", async (IMongoClient client) =>
{
    var database = client.GetDatabase("MySuperiorDB");
    var collection = database.GetCollection<People>("People");

    var people = await collection.Find<People>(_ => true).ToListAsync();
    return people;
});


app.Run();
