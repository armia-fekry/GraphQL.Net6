using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GraphQl.CustomerType
{
	public class CustomerType:ObjectType<Customer>
	{
		protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
		{
			//base.Configure(descriptor);
			descriptor.Description("This iS Customers List ");
			descriptor.Field(e => e.Phone).Ignore();

			descriptor.Field(e => e.CustomerAddresses)
				.ResolveWith<Resolver>(e => e.GetCustomerAdresses(default, default))
				.UseDbContext<AdventureWorksLT2019Context>()
				.Description("Address Lines ");

		}
		public class Resolver
		{
			public IQueryable<CustomerAddress> GetCustomerAdresses([Parent]Customer customer,[ScopedService] AdventureWorksLT2019Context context)
			{
				 var xx=context.CustomerAddresses.Where(e => e.CustomerId == customer.CustomerId);
				return xx;
			}
		}
	}
}
