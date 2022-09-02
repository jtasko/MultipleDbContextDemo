using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using MultipleDbContextDemo.TestSqlServerEntities;

namespace MultipleDbContextDemo.Web.Pages.TestSqlServerEntities
{
    public class EditModalModel : MultipleDbContextDemoPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TestSqlServerEntityUpdateDto TestSqlServerEntity { get; set; }

        private readonly ITestSqlServerEntitiesAppService _testSqlServerEntitiesAppService;

        public EditModalModel(ITestSqlServerEntitiesAppService testSqlServerEntitiesAppService)
        {
            _testSqlServerEntitiesAppService = testSqlServerEntitiesAppService;
        }

        public async Task OnGetAsync()
        {
            var testSqlServerEntity = await _testSqlServerEntitiesAppService.GetAsync(Id);
            TestSqlServerEntity = ObjectMapper.Map<TestSqlServerEntityDto, TestSqlServerEntityUpdateDto>(testSqlServerEntity);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _testSqlServerEntitiesAppService.UpdateAsync(Id, TestSqlServerEntity);
            return NoContent();
        }
    }
}