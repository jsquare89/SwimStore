using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Products;
using SwimStoreApi.GraphQL.ProductStocks;

namespace SwimStoreApi.GraphQL.Queries;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        base.Configure(descriptor);

        //descriptor.Field(q => q.GetProduct(default))
        //    .Type<ListType<ProductType>>();

        //descriptor.Field(q => q.GetProductStocks(default))
        //    .Type<ListType<ProductStockType>>();


        //descriptor.Field(q => q.GetBrands(default))
        //    .Type<ListType<BrandType>>();
    }
}
