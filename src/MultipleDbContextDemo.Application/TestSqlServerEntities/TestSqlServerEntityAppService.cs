using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MultipleDbContextDemo.TestSqlServerEntities
{

    [Authorize]
    public class TestSqlServerEntitiesAppService : ApplicationService, ITestSqlServerEntitiesAppService
    {
        private readonly ITestSqlServerEntityRepository _testSqlServerEntityRepository;

        public TestSqlServerEntitiesAppService(ITestSqlServerEntityRepository testSqlServerEntityRepository)
        {
            _testSqlServerEntityRepository = testSqlServerEntityRepository;
        }

        public virtual async Task<PagedResultDto<TestSqlServerEntityDto>> GetListAsync(GetTestSqlServerEntitiesInput input)
        {
            var totalCount = await _testSqlServerEntityRepository.GetCountAsync(input.FilterText, input.Name);
            var items = await _testSqlServerEntityRepository.GetListAsync(input.FilterText, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TestSqlServerEntityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TestSqlServerEntity>, List<TestSqlServerEntityDto>>(items)
            };
        }

        public virtual async Task<TestSqlServerEntityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TestSqlServerEntity, TestSqlServerEntityDto>(await _testSqlServerEntityRepository.GetAsync(id));
        }

        [Authorize]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _testSqlServerEntityRepository.DeleteAsync(id);
        }

        [Authorize]
        public virtual async Task<TestSqlServerEntityDto> CreateAsync(TestSqlServerEntityCreateDto input)
        {

            var testSqlServerEntity = ObjectMapper.Map<TestSqlServerEntityCreateDto, TestSqlServerEntity>(input);

            testSqlServerEntity = await _testSqlServerEntityRepository.InsertAsync(testSqlServerEntity, autoSave: true);
            return ObjectMapper.Map<TestSqlServerEntity, TestSqlServerEntityDto>(testSqlServerEntity);
        }

        [Authorize]
        public virtual async Task<TestSqlServerEntityDto> UpdateAsync(Guid id, TestSqlServerEntityUpdateDto input)
        {

            var testSqlServerEntity = await _testSqlServerEntityRepository.GetAsync(id);
            ObjectMapper.Map(input, testSqlServerEntity);
            testSqlServerEntity = await _testSqlServerEntityRepository.UpdateAsync(testSqlServerEntity, autoSave: true);
            return ObjectMapper.Map<TestSqlServerEntity, TestSqlServerEntityDto>(testSqlServerEntity);
        }
    }
}