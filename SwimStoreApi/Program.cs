using Serilog;
using SwimStoreApi;
using SwimStoreApi.DapperAttributeMapper;

var builder = WebApplication.CreateBuilder(args);

builder.UseSwimStoreWebApi();
builder.UseGraphQl();
builder.ConfigureSerilog();

DapperTypeMapper.Initialize("SwimStoreData.Models");

var app = builder.Build();

app.MapGraphQL("/graphql");
app.UseSerilogRequestLogging();

app.Run();