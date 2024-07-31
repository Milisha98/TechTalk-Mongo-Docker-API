var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder
            .AddMongoDB("mongo")
            .WithDataVolume("my-mongo-api")
            .WithMongoExpress();

builder
    .AddProject<Projects.Mongo_Docker_API>("mongo-docker-api")
    .WithReference(mongo);

builder.Build().Run();
