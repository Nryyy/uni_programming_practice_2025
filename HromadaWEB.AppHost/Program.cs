var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.HromadaWEB_ApiService>("apiservice");

builder.AddProject<Projects.HromadaWEB_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
