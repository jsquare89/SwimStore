using FluentMigrator.Runner;
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
                databaseService.CreateDatabase();
                migrationService.ListMigrations();
                migrationService.MigrateUp();
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
        builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2012()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("SwimStorePostgresDb"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

        return builder;
    }
}
