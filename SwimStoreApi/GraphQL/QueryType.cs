using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Products;

namespace SwimStoreApi.GraphQL;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(q => q.GetProduct(default))
            .Type <ListType<ProductType>>();

        //descriptor.Field(q => q.GetBrands(default))
        //    .Type<ListType<BrandType>>();
    }
}
