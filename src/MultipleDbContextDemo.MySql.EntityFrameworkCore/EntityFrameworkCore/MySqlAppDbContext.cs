using EfCoreMultiContextApp.MySql.TestMySqlEntities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MultipleDbContextDemo.MySql.EntityFrameworkCore;

[ConnectionStringName("MySql")]
public class MySqlAppDbContext : AbpDbContext<MySqlAppDbContext>
{
    public DbSet<TestMySqlEntity> TestMySqlEntities { get; set; }

    public MySqlAppDbContext(DbContextOptions<MySqlAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TestMySqlEntity>(b =>
        {
            b.ToTable(MultipleDbContextDemoConsts.DbTablePrefix + "TestMySqlEntities", MultipleDbContextDemoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).HasColumnName(nameof(TestMySqlEntity.Name));
        });
    }
}