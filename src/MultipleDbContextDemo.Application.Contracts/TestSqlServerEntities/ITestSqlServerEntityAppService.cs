using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MultipleDbContextDemo.TestSqlServerEntities
{
    public interface ITestSqlServerEntitiesAppService : IApplicationService
    {
        Task<PagedResultDto<TestSqlServerEntityDto>> GetListAsync(GetTestSqlServerEntitiesInput input);

        Task<TestSqlServerEntityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TestSqlServerEntityDto> CreateAsync(TestSqlServerEntityCreateDto input);

        Task<TestSqlServerEntityDto> UpdateAsync(Guid id, TestSqlServerEntityUpdateDto input);
    }
}