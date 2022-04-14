using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.GraphQl.SalesOrderDetails
{
	public class SalesOrderDataLoader : BatchDataLoader<int, SalesOrderDetail>
	{
		private readonly IDbContextFactory<AdventureWorksLT2019Context> dbContextFactory;

		public SalesOrderDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AdventureWorksLT2019Context> dbContextFactory) : base(batchScheduler)
		{
			this.dbContextFactory = dbContextFactory;
		}
		protected override async Task<IReadOnlyDictionary<int, SalesOrderDetail>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
		{
			await using AdventureWorksLT2019Context dbconText =
				dbContextFactory.CreateDbContext();
			return await dbconText.SalesOrderDetails.Where(s => keys.Contains(s.ProductId))
				.ToDictionaryAsync(e => e.ProductId, cancellationToken);
		}
	}
}
