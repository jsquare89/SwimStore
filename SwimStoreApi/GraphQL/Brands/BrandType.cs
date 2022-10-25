using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.Brands;

public class BrandType : ObjectType<Brand>
{
    protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Description("Represents a brand in the store.");
    }
}
