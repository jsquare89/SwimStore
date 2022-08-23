using SwimStoreData.Models;

namespace SwimStoreApi.GraphQL.Products;

public class ProductType: ObjectType<ProductModel>
{
    protected override void Configure(IObjectTypeDescriptor<ProductModel> descriptor)
    {
        descriptor.Description("Represents a product in the store.");


    }
}
