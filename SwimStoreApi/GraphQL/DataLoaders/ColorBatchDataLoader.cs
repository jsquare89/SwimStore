using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.DataLoaders;

public class ColorBatchDataLoader : BatchDataLoader<int, Color>
{
    private readonly IColorData _colorData;
    private readonly IMapper _mapper;

    public ColorBatchDataLoader(
        IColorData colorData,
        IMapper mapper,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _colorData = colorData;
        _mapper = mapper;
    }
    protected override async Task<IReadOnlyDictionary<int, Color>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var colorDtos = await _colorData.GetColorsByIds(keys);
        var colors = _mapper.Map<IEnumerable<Color>>(colorDtos);
        return colors.ToDictionary(x => x.Id);
    }
}
