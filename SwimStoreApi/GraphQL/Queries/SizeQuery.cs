using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Queries;
[ExtendObjectType(typeof(Query))]
public class SizeQuery
{
	private readonly IMapper _mapper;

	public SizeQuery(IMapper mapper)
	{
		_mapper = mapper;
	}

    [UseFiltering]
    public async Task<IEnumerable<Size>> GetSizes([Service] ISizeData sizeData)
    {
        var sizes = await sizeData.GetSizes();
        return _mapper.Map<IEnumerable<Size>>(sizes);
    }

    [UseFiltering]
    public async Task<Size?> GetSizeById(int id, [Service] ISizeData sizeData)
    {
        var size = await sizeData.GetSizeById(id);
        return _mapper.Map<Size>(size);
    }

}
