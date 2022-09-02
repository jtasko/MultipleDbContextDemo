using MultipleDbContextDemo.EntityFrameworkCore;
using MultipleDbContextDemo.MySql.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MultipleDbContextDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MultipleDbContextDemoEntityFrameworkCoreModule),
    typeof(MultipleDbContextDemoApplicationContractsModule),
    typeof(MySqlAppEntityFrameworkCoreModule)
    )]

public class MultipleDbContextDemoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
