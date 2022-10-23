using Serilog;
using SwimStoreApi.DapperAttributeMapper;
using SwimStoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.UseSwimStoreWebApi();
builder.ConfigureGraphQL();
builder.ConfigureSerilog();
DapperTypeMapper.Initialize("SwimStoreData.Models");

var app = builder.Build();

app.MigrateDatabase();
app.UseGraphQLVoyager();
app.UseSerilogRequestLogging();

app.MapSwimStoreApi();

app.Run();

