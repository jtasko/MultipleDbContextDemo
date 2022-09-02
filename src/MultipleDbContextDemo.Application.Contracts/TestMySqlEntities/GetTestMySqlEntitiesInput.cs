using Volo.Abp.Application.Dtos;
using System;

namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{
    public class GetTestMySqlEntitiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }

        public GetTestMySqlEntitiesInput()
        {

        }
    }
}