using HotChocolate.Types;

namespace Domain.GraphQl.CustomerAdresses
{
	public class CustomerAdressType:ObjectType<CustomerAddress>
	{
		protected override void Configure(IObjectTypeDescriptor<CustomerAddress> descriptor)
		{
			descriptor.Description("THIS Is Customer Adresses");
			descriptor.Field(e => e.AddressId);
		}
	}
}
