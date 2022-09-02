using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MultipleDbContextDemo.MySql.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MySqlAppDbContextFactory : IDesignTimeDbContextFactory<MySqlAppDbContext>
{
    public MySqlAppDbContext CreateDbContext(string[] args)
    {
        MySqlAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MySqlAppDbContext>()
            .UseMySql(configuration.GetConnectionString("MySql"), ServerVersion.AutoDetect(configuration.GetConnectionString("MySql")));

        return new MySqlAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MultipleDbContextDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
