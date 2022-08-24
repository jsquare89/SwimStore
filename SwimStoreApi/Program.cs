using Dapper;
using Serilog;
using SwimStoreApi;
using SwimStoreApi.DapperAttributeMapper;
using SwimStoreApi.GraphQL;
using SwimStoreData.Data;
using SwimStoreData.DataAccess;
using SwimStoreData.Models;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//This section to change
builder.Services.AddSingleton<IPostgresqlDataAccess, PostgresqlDataAccess>();
builder.Services.AddSingleton<IProductData, ProductData>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

ConfigureSerilog(builder);

DapperTypeMapper.Initialize("SwimStoreData.Models");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL("/graphql");

app.UseSerilogRequestLogging();

try
{
    Log.Information("Application Starting Up!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly.");
}
finally
{
    Log.CloseAndFlush();
}

static void ConfigureSerilog(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    builder.Host.UseSerilog();
}