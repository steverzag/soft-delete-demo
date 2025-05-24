var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SoftDeleteDemo_API>("softdeletedemo-api");

builder.Build().Run();
