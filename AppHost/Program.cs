using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Add PostgreSQL database container
var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin();

// Add the goals database
var db = postgres.AddDatabase("goalsdb");

// Add the backend .NET API service
var backend = builder.AddProject("backend", "../backend/backend.csproj")
    .WithReference(db)
    .WaitFor(db)
    .WithHttpEndpoint(port: 5000, targetPort: 8080, name: "http")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development");

builder.Build().Run();
