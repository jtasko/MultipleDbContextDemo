using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace MultipleDbContextDemo.TestSqlServerEntities
{
    public class TestSqlServerEntity : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Name { get; set; }

        public TestSqlServerEntity()
        {

        }

        public TestSqlServerEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}