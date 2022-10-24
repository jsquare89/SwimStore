using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using SwimStoreData.DataAccess;
using System.Reflection;

namespace SwimStoreApi.Extensions;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using(var serviceScope = app.Services.CreateScope())
        {
            var databaseService = serviceScope.ServiceProvider.GetRequiredService<IPostgresqlDataAccess>();
            var migrationService = serviceScope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            try
            {
                databaseService.CreateDatabase( "swimstoretestdb");
                migrationService.ListMigrations();
                migrationService.MigrateUp();
                // run down to version.
                //migrationService.MigrateDown(0);
            }
            catch
            {
                //TODO: log
                throw;
            }
        }
        return app;
    }

    public static WebApplicationBuilder AddFluentMigration(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentMigratorCore()
                        .AddLogging(c => c.AddFluentMigratorConsole())
                        .ConfigureRunner(c => c.AddPostgres11_0()
                            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("SwimStoreTestDb"))
                            .ScanIn(AppDomain.CurrentDomain.GetAssemblies()));
        return builder;
    }
}
