namespace SwimStoreData.DataAccess;

public interface IPostgresqlDataAccess
{
    void CreateDatabase(string dbName = "swimstoredb", string connectionId = "DbConnection");
    Task<IEnumerable<T>> LoadDataWithFunction<T, U>(string function, U parameters, string connectionId = "SwimStorePostgresDb");
    Task<IEnumerable<T>> LoadDataWithSql<T, U>(string sqlQuery, U parameters, string connectionId = "SwimStorePostgresDb");
    Task SaveDataWithProcedure<T>(string procedure, T parameters, string connectionId = "SwimStorePostgresDb");
    Task<dynamic> SaveDataWithSql<T>(string sqlQuery, T parameters, string connectionId = "SwimStorePostgresDb");
}