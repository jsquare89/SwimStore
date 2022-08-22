namespace SwimStoreData.DataAccess;

public interface IPostgresqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "SwimStorePostgresDb");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "SwimStorePostgresDb");
}