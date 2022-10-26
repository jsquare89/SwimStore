using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Sizes;

public class SizeBatchDataLoader : BatchDataLoader<int, Size>
{
	private readonly ISizeData _sizeData;
	private readonly IMapper _mapper;

	public SizeBatchDataLoader(
		ISizeData sizeData,
		IMapper mapper,
		IBatchScheduler batchScheduler,
		DataLoaderOptions? options = null)
		: base(batchScheduler, options)
	{
		_sizeData = sizeData;
		_mapper = mapper;
	}

	protected override async Task<IReadOnlyDictionary<int, Size>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
	{
        var sizeDtos = await _sizeData.GetSizesByIds(keys);
        var sizes = _mapper.Map<IEnumerable<Size>>(sizeDtos);
        return sizes.ToDictionary(x => x.Id);
    }
}
