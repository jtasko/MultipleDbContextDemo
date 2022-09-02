using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace EfCoreMultiContextApp.MySql.TestMySqlEntities
{
    public class TestMySqlEntity : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Name { get; set; }

        public TestMySqlEntity()
        {

        }

        public TestMySqlEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}