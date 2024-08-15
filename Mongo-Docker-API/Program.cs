using Dapr.Client;
using Mongo_Docker_API;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDaprClient();
//builder.AddMongoDBClient("mongo");

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", async (DaprClient client) =>
{
    // Save a new Record
    var person = new People { Id = 7, Name = "Foo Bar" };
    await client.SaveStateAsync<People>("statestore", "7", person);

    // Fetch a Record
    var people = await client.GetStateAsync<People>("statestore", "7");
    return people;

});


app.Run();
