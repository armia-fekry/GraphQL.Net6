using HotChocolate;
using HotChocolate.Types;

namespace Domain.GraphQl
{
	public class Subscribtion
	{
		[Subscribe]
		[Topic]
		public ProductModel OnProductModelAdd([EventMessage] ProductModel productModel)
		{
			return productModel;
		}
	}
}
