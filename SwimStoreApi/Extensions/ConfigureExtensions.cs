using Serilog;
using SwimStoreApi.GraphQL;
using SwimStoreData.Data;
using SwimStoreData.DataAccess;

namespace SwimStoreApi.Extensions;

public static class ConfigureExtentions
{
    public static WebApplicationBuilder UseSwimStoreWebApi(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPostgresqlDataAccess, PostgresqlDataAccess>();
        builder.Services.AddSingleton<IProductData, ProductData>();

        return builder;
    }

    public static WebApplicationBuilder ConfigureSerilog(
    this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog();
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
        builder.Logging.AddSerilog(Log.Logger);
        return builder;
    }

    public static WebApplicationBuilder ConfigureGraphQL(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddFiltering();
        return builder;
    }

    public static WebApplication MapSwimStoreApi(
        this WebApplication app)
    {
        app.MapGraphQL("/graphql");
        app.MapGraphQLVoyager("/graphql-voyager");
        return app;
    }
}
