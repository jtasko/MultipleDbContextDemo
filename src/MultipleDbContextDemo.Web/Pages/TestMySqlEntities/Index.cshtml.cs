using MultipleDbContextDemo.MySql.TestMySqlEntities;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MultipleDbContextDemo.Web.Pages.MySql.TestMySqlEntities
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }

        private readonly ITestMySqlEntitiesAppService _testMySqlEntitiesAppService;

        public IndexModel(ITestMySqlEntitiesAppService testMySqlEntitiesAppService)
        {
            _testMySqlEntitiesAppService = testMySqlEntitiesAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}