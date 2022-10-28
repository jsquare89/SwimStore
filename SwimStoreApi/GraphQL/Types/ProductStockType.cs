using SwimStoreApi.GraphQL.DataLoaders;
using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.Types;

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
        descriptor.Field(p => p.ColorId)
            .Ignore();
        descriptor.Field<ProductStockType>(p => ResolveColor(default, default))
            .Name("color")
            .Type<ColorType>();
        descriptor.Field(p => p.SizeId)
           .Ignore();
        descriptor.Field<ProductStockType>(p => ResolveSize(default, default))
            .Name("size")
            .Type<SizeType>();
        descriptor.Field(p => p.Quantity)
            .Type<NonNullType<IntType>>();
    }

    public async Task<Product?> ResolveProduct(ProductBatchDataLoader dataLoader, [Parent] ProductStock productStock)
    {
        var product = await dataLoader.LoadAsync(productStock.ProductId);
        return product;
    }

    public async Task<Color?> ResolveColor(ColorBatchDataLoader dataLoader, [Parent] ProductStock productStock)
    {
        var color = await dataLoader.LoadAsync(productStock.ColorId);
        return color;
    }

    public async Task<Size?> ResolveSize(SizeBatchDataLoader dataLoader, [Parent] ProductStock productStock)
    {
        var size = await dataLoader.LoadAsync(productStock.SizeId);
        return size;
    }
}
