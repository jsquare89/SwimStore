using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Queries;
[ExtendObjectType(typeof(Query))]
public class ColorQuery
{
	private readonly IMapper _mapper;

	public ColorQuery(IMapper mapper)
	{
		_mapper = mapper;
	}

    [UseFiltering]
    public async Task<IEnumerable<Color>> GetColors([Service] IColorData colorData)
    {
        var colors = await colorData.GetColors();
        return _mapper.Map<IEnumerable<Color>>(colors);
    }

    [UseFiltering]
    public async Task<Color?> GetColorById(int id, [Service] IColorData colorData)
    {
        var color = await colorData.GetColorById(id);
        return _mapper.Map<Color>(color);
    }
}
