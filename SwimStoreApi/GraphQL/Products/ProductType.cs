using SwimStoreData.Models;

namespace SwimStoreApi.GraphQL.Products;

public class ProductType: ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor.Description("Represents a product in the store.");


    }
}
