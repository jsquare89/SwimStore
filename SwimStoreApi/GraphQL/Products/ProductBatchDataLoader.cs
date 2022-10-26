using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Products;

public class ProductBatchDataLoader : BatchDataLoader<int, Product>
{
    private readonly IProductData _productData;
    private readonly IMapper _mapper;

    public ProductBatchDataLoader(
        IProductData productData,
        IMapper mapper,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _productData = productData;
        _mapper = mapper;
    }
    protected override async Task<IReadOnlyDictionary<int, Product>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var productDtos = await _productData.GetProductsByIds(keys);
        var products = _mapper.Map<IEnumerable<Product>>(productDtos);
        return products.ToDictionary(x => x.Id);
    }
}
