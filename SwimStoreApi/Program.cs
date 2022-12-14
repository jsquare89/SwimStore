using Serilog;
using SwimStoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSwimStoreData();
builder.ConfigureAuthentication();
builder.ConfigureGraphQL();
builder.ConfigureSerilog();
builder.AddFluentMigration();

var app = builder.Build();

app.MigrateDatabase();
app.UseGraphQLVoyager();
app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapSwimStoreApi();

app.Run();

