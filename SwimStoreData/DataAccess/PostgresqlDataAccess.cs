using Dapper;
using Microsoft.Extensions.Configuration;
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

    public PostgresqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadDataWithFunction<T, U>(
        string function,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(function, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> LoadDataWithSql<T, U>(
        string sqlQuery,
        U parameters,
        string connectionId = "SwimStorePostgresDb")
    {
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

    public async Task SaveDataWithSql<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "SwimStorePostgresDb")
    {
        using IDbConnection connection = new NpgsqlConnection(connectionId);

        await connection.ExecuteAsync(sqlQuery, parameters, commandType: CommandType.Text);
    }
}
