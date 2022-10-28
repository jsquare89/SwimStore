using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class ProductQuery
{
    private readonly IMapper _mapper;

    public ProductQuery(IMapper mapper)
    {
        _mapper = mapper;
    }

    [UseFiltering]
    public async Task<IEnumerable<Product>> GetProduct([Service] IProductData productData)
    {
        var products = await productData.GetProducts();
        return _mapper.Map<IEnumerable<Product>>(products);
    }

    [UseFiltering]
    public async Task<Product?> GetProductById(int id, [Service] IProductData productData)
    {
        var product = await productData.GetProductById(id);
        return _mapper.Map<Product>(product);
    }
}
