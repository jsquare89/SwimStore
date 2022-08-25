using Serilog;
using SwimStoreApi.GraphQL;
using SwimStoreData.Data;
using SwimStoreData.DataAccess;

namespace SwimStoreApi;

public static class SwimStoreExtensions
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

    public static WebApplicationBuilder UseGraphQl(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddFiltering();
        return builder;
    }
}
