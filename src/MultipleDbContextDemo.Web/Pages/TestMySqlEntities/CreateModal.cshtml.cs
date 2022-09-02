using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleDbContextDemo.MySql.TestMySqlEntities;

namespace MultipleDbContextDemo.Web.Pages.MySql.TestMySqlEntities
{
    public class CreateModalModel : MultipleDbContextDemoPageModel
    {
        [BindProperty]
        public TestMySqlEntityCreateDto TestMySqlEntity { get; set; }

        private readonly ITestMySqlEntitiesAppService _testMySqlEntitiesAppService;

        public CreateModalModel(ITestMySqlEntitiesAppService testMySqlEntitiesAppService)
        {
            _testMySqlEntitiesAppService = testMySqlEntitiesAppService;
        }

        public async Task OnGetAsync()
        {
            TestMySqlEntity = new TestMySqlEntityCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _testMySqlEntitiesAppService.CreateAsync(TestMySqlEntity);
            return NoContent();
        }
    }
}