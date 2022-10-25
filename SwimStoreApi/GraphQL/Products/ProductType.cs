using AutoMapper;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Products;

public class ProductType: ObjectType<Product>
{
    private readonly IMapper _mapper;

    public ProductType(IMapper mapper)
    {
        _mapper = mapper;
    }
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
        descriptor.Field<ProductType>(p => ResolveBrand(default, default))
            .Name("brand")
            .Type<BrandType>();
        //descriptor.Field<ProductType>(p => ResolveCategory(default, default))
        //    .Name("brand")
        //    .Type<CategoryType>();

    }
    public async Task<Brand?> ResolveBrand([Service] IBrandData brandData, [Parent] Product product)
    {
        var brand = await brandData.GetBrandById(product.BrandId);
        return _mapper.Map<Brand>(brand);
    }
    //public async Task<Category?> ResolveCategory(object value1, object value2)
    //{
    //    throw new NotImplementedException();
    //}


}
