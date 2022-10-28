using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.DataLoaders;

public class CategoryBatchDataLoader : BatchDataLoader<int, Category>
{
    private readonly ICategoryData _categoryData;
    private readonly IMapper _mapper;

    public CategoryBatchDataLoader(
        ICategoryData categoryData,
        IMapper mapper,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _categoryData = categoryData;
        _mapper = mapper;
    }
    protected override async Task<IReadOnlyDictionary<int, Category>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var categoryDtos = await _categoryData.GetCategoriesByIds(keys);
        var categories = _mapper.Map<IEnumerable<Category>>(categoryDtos);
        return categories.ToDictionary(x => x.Id);
    }
}
