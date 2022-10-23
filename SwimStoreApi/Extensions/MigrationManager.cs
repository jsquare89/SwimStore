using SwimStoreData.DataAccess;
using System.Runtime.CompilerServices;

namespace SwimStoreApi.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this WebApplication app)
    {
        using(var serviceScope = app.Services.CreateScope())
        {
            var databaseService = serviceScope.ServiceProvider.GetRequiredService<IPostgresqlDataAccess>();

            try
            {
                databaseService.CreateDatabase("DbConnection","swimstoredb");
            }
            catch
            {
                //TODO: log
                throw;
            }
        }
        return app;
    }
}
