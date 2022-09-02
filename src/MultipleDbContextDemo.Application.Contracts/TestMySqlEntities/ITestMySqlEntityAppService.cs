using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{
    public interface ITestMySqlEntitiesAppService : IApplicationService
    {
        Task<PagedResultDto<TestMySqlEntityDto>> GetListAsync(GetTestMySqlEntitiesInput input);

        Task<TestMySqlEntityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TestMySqlEntityDto> CreateAsync(TestMySqlEntityCreateDto input);

        Task<TestMySqlEntityDto> UpdateAsync(Guid id, TestMySqlEntityUpdateDto input);
    }
}