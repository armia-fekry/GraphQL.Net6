using Domain.GraphQl.Product;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.GraphQl
{
	public class RootMutaion
	{
		#region Simple Mutation
		//[UseDbContext(typeof(AdventureWorksLT2019Context))]
		//public async Task<AddProductModelPayLoad> AddProductModel(AddProductModelInput input,
		//	[ScopedService] AdventureWorksLT2019Context context
		//	)
		//{
		//	var ProductModel = new ProductModel()
		//	{
		//		Name = input.Name
		//	};
		//	 context.ProductModels.Add(ProductModel);
		//	await context.SaveChangesAsync();
		//	return new AddProductModelPayLoad(ProductModel);
		//} 
		#endregion


		#region Mutaion With Subscribtion
		//[UseDbContext(typeof(AdventureWorksLT2019Context))]
		public async Task<AddProductModelPayLoad> AddProductModel(AddProductModelInput input,
			//[ScopedService] AdventureWorksLT2019Context context
			 AdventureWorksLT2019Context context
			, [Service] ITopicEventSender eventSender

			)
		{
			var ProductModel = new ProductModel()
			{
				Name = input.Name
			};
			context.ProductModels.Add(ProductModel);
			await context.SaveChangesAsync();
			await eventSender.SendAsync(nameof(Subscribtion.OnProductModelAdd), ProductModel);
			return new AddProductModelPayLoad(ProductModel);
		}
		#endregion
	}
}
