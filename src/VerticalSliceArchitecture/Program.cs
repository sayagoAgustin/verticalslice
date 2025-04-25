using Scalar.AspNetCore;
using System.Reflection;
using VerticalSliceArchitecture;
using VerticalSliceArchitecture.Host;

var appAssembly = Assembly.GetExecutingAssembly();
var builder = WebApplication.CreateBuilder(args);

// Common
builder.Services.AddEfCore();

// Host
builder.Services.AddVerticalSliceArchitectureHandlers();
builder.Services.AddVerticalSliceArchitectureBehaviors();

builder.Services.AddMediatR(configure => configure.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddExceptionHandler<ExceptionHandler.KnownExceptionsHandler>();

builder.Services.ConfigureFeatures(builder.Configuration, appAssembly);

builder.Services.AddOpenApi();

Console.WriteLine(builder.Configuration.GetConnectionString("todoDb"));

var app = builder.Build();
// Ejecutar migraciones
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseProductionExceptionHandler();

app.RegisterEndpoints(appAssembly);

await app.RunAsync();

public partial class Program;