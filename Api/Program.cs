using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiSrvices(builder.Configuration)
    .AddInfrastructureSrvices(builder.Configuration)
    .AddAplicationsSrvices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.UseApiServices();

app.Run();
