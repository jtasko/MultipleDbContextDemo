using System;
using Volo.Abp.Application.Dtos;

namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{
    public class TestMySqlEntityDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}