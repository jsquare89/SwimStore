using Serilog;
using SwimStoreApi;
using SwimStoreApi.DapperAttributeMapper;

var builder = WebApplication.CreateBuilder(args);

builder.UseSwimStoreWebApi();
builder.ConfigureGraphQL();
builder.ConfigureSerilog();
DapperTypeMapper.Initialize("SwimStoreData.Models");

var app = builder.Build();

app.UseGraphQLVoyager();
app.UseSerilogRequestLogging();

app.MapSwimStoreApi();

app.Run();

