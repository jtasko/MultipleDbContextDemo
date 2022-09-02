using MultipleDbContextDemo.TestSqlServerEntities;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MultipleDbContextDemo.Web.Pages.TestSqlServerEntities
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }

        private readonly ITestSqlServerEntitiesAppService _testSqlServerEntitiesAppService;

        public IndexModel(ITestSqlServerEntitiesAppService testSqlServerEntitiesAppService)
        {
            _testSqlServerEntitiesAppService = testSqlServerEntitiesAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}