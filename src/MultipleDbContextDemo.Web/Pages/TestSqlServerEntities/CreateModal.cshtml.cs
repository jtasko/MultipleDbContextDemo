using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleDbContextDemo.TestSqlServerEntities;

namespace MultipleDbContextDemo.Web.Pages.TestSqlServerEntities
{
    public class CreateModalModel : MultipleDbContextDemoPageModel
    {
        [BindProperty]
        public TestSqlServerEntityCreateDto TestSqlServerEntity { get; set; }

        private readonly ITestSqlServerEntitiesAppService _testSqlServerEntitiesAppService;

        public CreateModalModel(ITestSqlServerEntitiesAppService testSqlServerEntitiesAppService)
        {
            _testSqlServerEntitiesAppService = testSqlServerEntitiesAppService;
        }

        public async Task OnGetAsync()
        {
            TestSqlServerEntity = new TestSqlServerEntityCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _testSqlServerEntitiesAppService.CreateAsync(TestSqlServerEntity);
            return NoContent();
        }
    }
}