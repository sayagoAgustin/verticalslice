var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres", port: 5432)
       .WithDataVolume(isReadOnly: false)
       .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

var postgresdb = postgres.AddDatabase("todoDb");

builder.AddProject<Projects.VerticalSliceArchitecture>("verticalslice")
    .WaitFor(postgresdb)
    .WithReference(postgresdb);

await builder.Build().RunAsync();



