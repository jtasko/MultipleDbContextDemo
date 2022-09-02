using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using MultipleDbContextDemo.MySql.TestMySqlEntities;

namespace MultipleDbContextDemo.Web.Pages.MySql.TestMySqlEntities
{
    public class EditModalModel : MultipleDbContextDemoPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TestMySqlEntityUpdateDto TestMySqlEntity { get; set; }

        private readonly ITestMySqlEntitiesAppService _testMySqlEntitiesAppService;

        public EditModalModel(ITestMySqlEntitiesAppService testMySqlEntitiesAppService)
        {
            _testMySqlEntitiesAppService = testMySqlEntitiesAppService;
        }

        public async Task OnGetAsync()
        {
            var testMySqlEntity = await _testMySqlEntitiesAppService.GetAsync(Id);
            TestMySqlEntity = ObjectMapper.Map<TestMySqlEntityDto, TestMySqlEntityUpdateDto>(testMySqlEntity);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _testMySqlEntitiesAppService.UpdateAsync(Id, TestMySqlEntity);
            return NoContent();
        }
    }
}