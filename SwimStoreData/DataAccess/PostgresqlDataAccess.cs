using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace SwimStoreData.DataAccess;

public class PostgresqlDataAccess : IPostgresqlDataAccess
{
    private readonly IConfiguration _config;
    private readonly ILogger<PostgresqlDataAccess> _logger;

    public PostgresqlDataAccess(IConfiguration config, ILogger<PostgresqlDataAccess> logger)
    {
        _config = config;
        _logger = logger;
    }

    public void CreateDatabase(string dbName = "swimstoredb", string connectionId = "DbConnection")
    {
        var query = "SELECT datname FROM pg_catalog.pg_database WHERE lower(datname) = lower(@name);";
        var parameters = new DynamicParameters();
        parameters.Add("name", dbName);

        using IDbConnection connection = new NpgsqlConnection(
            _config.GetConnectionString(connectionId));

        var result = connection.Query(query, parameters);
        if (!result.Any())
            connection.Execute($"CREATE DATABASE {dbName}");
    }

    public async Task<IEnumerable<T>> LoadDataWithFunction<T, U>(
        string function,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> Stored Function ======\n" +
            "\t{function}", function);

        using IDbConnection connection = new NpgsqlConnection(
            _config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(function, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> LoadDataWithSql<T, U>(
        string sqlQuery,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> SQL ======\n" +
            "\t{sqlQuery}", sqlQuery);

        using IDbConnection connection = new NpgsqlConnection(
            _config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(sqlQuery, parameters, commandType: CommandType.Text);
    }

    public async Task SaveDataWithProcedure<T>(
        string procedure,
        T parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        using IDbConnection connection = new NpgsqlConnection(
            _config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<dynamic> SaveDataWithSql<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> SQL ======\n" +
            "\t{sqlQuery}", sqlQuery);

        using IDbConnection connection = new NpgsqlConnection(
            _config.GetConnectionString(connectionId));
       
        return await connection.QuerySingleAsync(sqlQuery, parameters, commandType: CommandType.Text);
    }
}
