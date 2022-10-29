using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SwimStoreApi.DapperAttributeMapper;
using SwimStoreApi.GraphQL.Mutations;
using SwimStoreApi.GraphQL.Queries;
using SwimStoreData.Data;
using SwimStoreData.DataAccess;
using System.Text;
using HotChocolate.AspNetCore.Authorization;

namespace SwimStoreApi.Extensions;

public static class ConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureSwimStoreData(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPostgresqlDataAccess, PostgresqlDataAccess>();
        builder.Services.AddSingleton<IProductData, ProductData>();
        builder.Services.AddSingleton<IBrandData, BrandData>();
        builder.Services.AddSingleton<ICategoryData, CategoryData>();
        builder.Services.AddSingleton<IProductStockData, ProductStockData>();
        builder.Services.AddSingleton<IColorData, ColorData>();
        builder.Services.AddSingleton<ISizeData, SizeData>();
        DapperTypeMapper.Initialize("SwimStoreData.Dtos");
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
            .AddAuthorization()
            .AddSwimStoreApiTypes()
            .AddQueryType<QueryType>()
            .AddMutationType<MutationType>()
            .AddMutationConventions(applyToAllMutations: true)
            .AddFiltering();
        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthentication(
       this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    //ValidateActor = true,
                    //ValidateAudience = true,
                    //ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
        builder.Services.AddAuthorization();

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
