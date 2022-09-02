using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using MultipleDbContextDemo.MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using EfCoreMultiContextApp.MySql.TestMySqlEntities;

namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{
    public class EfCoreTestMySqlEntityRepository : EfCoreRepository<MySqlAppDbContext, TestMySqlEntity, Guid>, ITestMySqlEntityRepository
    {
        public EfCoreTestMySqlEntityRepository(IDbContextProvider<MySqlAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<TestMySqlEntity>> GetListAsync(
            string filterText = null,
            string name = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TestMySqlEntityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TestMySqlEntity> ApplyFilter(
            IQueryable<TestMySqlEntity> query,
            string filterText,
            string name = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name));
        }
    }
}