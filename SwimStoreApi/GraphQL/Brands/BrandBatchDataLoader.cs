using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Brands;

public class BrandBatchDataLoader : BatchDataLoader<Int32, Brand>
{
    private readonly IBrandData _brandData;
    private readonly IMapper _mapper;

    public BrandBatchDataLoader(
        IBrandData brandData,
        IMapper mapper,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _brandData = brandData;
        _mapper = mapper;
    }
    protected override async Task<IReadOnlyDictionary<int, Brand>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var brandDtos = await _brandData.GetBrandsByIds(keys);
        var brands = _mapper.Map<IEnumerable<Brand>>(brandDtos);
        return brands.ToDictionary(x => x.Id);
    }
}
