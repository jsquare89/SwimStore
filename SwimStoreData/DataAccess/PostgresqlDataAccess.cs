using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async Task<IEnumerable<T>> LoadDataWithFunction<T, U>(
        string function,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> Stored Function ======\n" +
            "\t{function}", function);

        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(function, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> LoadDataWithSql<T, U>(
        string sqlQuery,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> SQL ======\n" +
            "\t{sqlQuery}", sqlQuery);

        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(sqlQuery, parameters, commandType: CommandType.Text);
    }

    public async Task SaveDataWithProcedure<T>(
        string procedure,
        T parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        using IDbConnection connection = new NpgsqlConnection(connectionId);

        await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<dynamic> SaveDataWithSql<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        _logger.LogInformation("====== Postgres Call -> SQL ======\n" +
            "\t{sqlQuery}", sqlQuery);

        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        try
        {
            var result = await connection.QuerySingleAsync(sqlQuery, parameters, commandType: CommandType.Text);
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
        }
        return null;
        //await connection.ExecuteAsync(sqlQuery, parameters, commandType: CommandType.Text);
    }
}
