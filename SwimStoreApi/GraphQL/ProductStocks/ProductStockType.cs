using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Products;
using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.ProductStocks;

public class ProductStockType : ObjectType<ProductStock>
{
    protected override void Configure(IObjectTypeDescriptor<ProductStock> descriptor)
    {
        base.Configure(descriptor);
        descriptor.Description("Represents a product with size,color and stock level in the store.");
        descriptor.Field(p => p.ProductId)
            .Ignore();
        descriptor.Field<ProductStockType>(p => ResolveProduct( default, default))
            .Name("product")
            .Type<ProductType>();
        descriptor.Field(p => p.SizeId)
            .Type<NonNullType<IntType>>();
        descriptor.Field(p => p.ColorId)
            .Type<NonNullType<IntType>>();
        descriptor.Field(p => p.Quantity)
            .Type<NonNullType<IntType>>();
    }

    public async Task<Product?> ResolveProduct(ProductBatchDataLoader dataLoader, [Parent] ProductStock productStock)
    {
        var product = await dataLoader.LoadAsync(productStock.ProductId);
        return product;
    }
}
