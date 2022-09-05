using System;
using System.Threading.Tasks;
using EfCoreMultiContextApp.MySql.TestMySqlEntities;
using MultipleDbContextDemo.TestSqlServerEntities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MultipleDbContextDemo;

public class MultipleDbContextDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<TestSqlServerEntity, Guid> _sqlServerEntityRepository;
    private readonly IRepository<TestMySqlEntity, Guid> _mySqlEntityRepository;

    public MultipleDbContextDataSeedContributor(IRepository<TestSqlServerEntity, Guid> sqlServerEntityRepository, IRepository<TestMySqlEntity, Guid> mySqlEntityRepository)
    {
        _sqlServerEntityRepository = sqlServerEntityRepository;
        _mySqlEntityRepository = mySqlEntityRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedTestSqlServerEntityAsync(context);
        await SeedTestMySqlServerEntityAsync(context);
    }

    private async Task SeedTestSqlServerEntityAsync(DataSeedContext context)
    {
        await _sqlServerEntityRepository.InsertAsync(new TestSqlServerEntity
        {
            Name = "Sql server entity"
        });
    }

    private async Task SeedTestMySqlServerEntityAsync(DataSeedContext context)
    {
        await _mySqlEntityRepository.InsertAsync(new TestMySqlEntity
        {
            Name = "MySql entity"
        });
    }
}