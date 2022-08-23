using Dapper;
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


DapperTypeMapper.Initialize("SwimStoreData.Models");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL("/graphql");

app.Run();


