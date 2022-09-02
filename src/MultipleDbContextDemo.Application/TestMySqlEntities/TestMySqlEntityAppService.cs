using EfCoreMultiContextApp.MySql.TestMySqlEntities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{

    [Authorize]
    public class TestMySqlEntitiesAppService : ApplicationService, ITestMySqlEntitiesAppService
    {
        private readonly ITestMySqlEntityRepository _testMySqlEntityRepository;

        public TestMySqlEntitiesAppService(ITestMySqlEntityRepository testMySqlEntityRepository)
        {
            _testMySqlEntityRepository = testMySqlEntityRepository;
        }

        public virtual async Task<PagedResultDto<TestMySqlEntityDto>> GetListAsync(GetTestMySqlEntitiesInput input)
        {
            var totalCount = await _testMySqlEntityRepository.GetCountAsync(input.FilterText, input.Name);
            var items = await _testMySqlEntityRepository.GetListAsync(input.FilterText, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TestMySqlEntityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TestMySqlEntity>, List<TestMySqlEntityDto>>(items)
            };
        }

        public virtual async Task<TestMySqlEntityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TestMySqlEntity, TestMySqlEntityDto>(await _testMySqlEntityRepository.GetAsync(id));
        }

        [Authorize]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _testMySqlEntityRepository.DeleteAsync(id);
        }

        [Authorize]
        public virtual async Task<TestMySqlEntityDto> CreateAsync(TestMySqlEntityCreateDto input)
        {

            var testMySqlEntity = ObjectMapper.Map<TestMySqlEntityCreateDto, TestMySqlEntity>(input);

            testMySqlEntity = await _testMySqlEntityRepository.InsertAsync(testMySqlEntity, autoSave: true);
            return ObjectMapper.Map<TestMySqlEntity, TestMySqlEntityDto>(testMySqlEntity);
        }

        [Authorize]
        public virtual async Task<TestMySqlEntityDto> UpdateAsync(Guid id, TestMySqlEntityUpdateDto input)
        {

            var testMySqlEntity = await _testMySqlEntityRepository.GetAsync(id);
            ObjectMapper.Map(input, testMySqlEntity);
            testMySqlEntity = await _testMySqlEntityRepository.UpdateAsync(testMySqlEntity, autoSave: true);
            return ObjectMapper.Map<TestMySqlEntity, TestMySqlEntityDto>(testMySqlEntity);
        }
    }
}