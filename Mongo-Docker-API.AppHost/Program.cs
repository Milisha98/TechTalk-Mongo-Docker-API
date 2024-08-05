var builder = DistributedApplication.CreateBuilder(args);

var stateStore = builder.AddDaprStateStore("statestore", new Aspire.Hosting.Dapr.DaprComponentOptions()
{
    LocalPath = "../Dapr/statestore.yaml"
});

var api = builder
            .AddProject<Projects.Mongo_Docker_API>("mongo-docker-api")
            .WithDaprSidecar()
            .WithReference(stateStore);

builder.Build().Run();
