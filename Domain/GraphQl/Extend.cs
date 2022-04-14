using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GraphQl
{
	[ExtendObjectType(nameof(ProductModel))]
	public class ExtendOfOrderDetails
	{
		public async Task<string> GetDetails()
		{
			await Task.Delay(500);
			return "Hello This is Details Of Orders";
		}
	}
}
