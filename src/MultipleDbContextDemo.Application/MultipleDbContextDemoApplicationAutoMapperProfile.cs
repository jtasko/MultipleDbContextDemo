using AutoMapper;
using EfCoreMultiContextApp.MySql.TestMySqlEntities;
using MultipleDbContextDemo.MySql.TestMySqlEntities;
using MultipleDbContextDemo.TestSqlServerEntities;
using Volo.Abp.AutoMapper;

namespace MultipleDbContextDemo;

public class MultipleDbContextDemoApplicationAutoMapperProfile : Profile
{
    public MultipleDbContextDemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TestSqlServerEntityCreateDto, TestSqlServerEntity>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        CreateMap<TestSqlServerEntityUpdateDto, TestSqlServerEntity>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        CreateMap<TestSqlServerEntity, TestSqlServerEntityDto>();

        CreateMap<TestMySqlEntityCreateDto, TestMySqlEntity>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        CreateMap<TestMySqlEntityUpdateDto, TestMySqlEntity>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        CreateMap<TestMySqlEntity, TestMySqlEntityDto>();

    }
}
