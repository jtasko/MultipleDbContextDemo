using Volo.Abp.Application.Dtos;
using System;

namespace MultipleDbContextDemo.TestSqlServerEntities
{
    public class GetTestSqlServerEntitiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }

        public GetTestSqlServerEntitiesInput()
        {

        }
    }
}