using HotChocolate;
using System.Linq;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using Domain.GraphQl.SalesOrderDetails;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Test
{
	
    public class RootQuery
    {
		//public IQueryable<Product> GetProducts([Service] AdventureWorksLT2019Context context) =>
		//	context.Products;

		#region Without Booled Db COntext
		//[UseProjection]
		//public IQueryable<Product> GetProducts2([Service] AdventureWorksLT2019Context context) =>
		//	context.Products;
		#endregion

		#region Booled DbContext
		
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Product> GetProducts3(AdventureWorksLT2019Context context) =>
			context.Products;
		#endregion

		//[UseDbContext(typeof(AdventureWorksLT2019Context))]
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<ProductModel> GetproductModels( AdventureWorksLT2019Context context) =>
		   context.ProductModels;

		//[UseDbContext(typeof(AdventureWorksLT2019Context))]
		public IQueryable<Customer> GetCustomers(AdventureWorksLT2019Context context)
			=> context.Customers.AsQueryable<Customer>();
		//[UseDbContext(typeof(AdventureWorksLT2019Context))]
		public IQueryable<CustomerAddress> GetCustomerAdresses(AdventureWorksLT2019Context context)
			=> context.CustomerAddresses;
		//public async IAsyncEnumerable<ProductModel> GetProductMoselsStream(AdventureWorksLT2019Context context, CancellationToken cancellation)
		//{
		//	await foreach (ProductModel product in context.ProductModels.AsAsyncEnumerable().WithCancellation(cancellation))
		//	{
		//		await Task.Delay(500);
		//		yield return product;
		//	}
		//}
		public Task<SalesOrderDetail> GetOrderDetails(
			int id,
			SalesOrderDataLoader dataLoader,
			CancellationToken cancellationToken) =>
			dataLoader.LoadAsync(id, cancellationToken);

	}
}
