using System;
using Volo.Abp.Application.Dtos;

namespace MultipleDbContextDemo.TestSqlServerEntities
{
    public class TestSqlServerEntityDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}