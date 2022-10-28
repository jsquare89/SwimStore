using SwimStoreApi.GraphQL.DataLoaders;
using SwimStoreApi.GraphQL.Types;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Types;

public class ProductType: ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        base.Configure(descriptor);
        descriptor.Description("Represents a product in the store.");
        descriptor.Field(p => p.Id)
            .Type<NonNullType<IdType>>();
        descriptor.Field(p => p.Name)
            .Type<NonNullType<StringType>>();
        descriptor.Field(p => p.RetailPrice)
            .Type<NonNullType<IntType>>();
        descriptor.Field(p => p.CurrentPrice)
            .Type<NonNullType<IntType>>();
        descriptor.Field(p => p.Description)
            .Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Features)
            .Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Sku)
            .Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Gender)
            .Type<NonNullType<StringType>>();
        descriptor.Field(p => p.BrandId)
            .Ignore();
        descriptor.Field<ProductType>(p => ResolveBrand( default, default))
            .Name("brand")
            .Type<BrandType>();
        descriptor.Field(p => p.CategoryId)
            .Ignore();
        descriptor.Field<ProductType>(p => ResolveCategory(default, default))
            .Name("category")
            .Type<CategoryType>();
    }
    public async Task<Brand?> ResolveBrand(BrandBatchDataLoader dataLoader, [Parent] Product product)
    {
        var brand = await dataLoader.LoadAsync(product.BrandId);
        return brand;
    }
    public async Task<Category?> ResolveCategory(CategoryBatchDataLoader dataLoader, [Parent] Product product)
    {
        var category = await dataLoader.LoadAsync(product.CategoryId);
        return category;
    }
}
