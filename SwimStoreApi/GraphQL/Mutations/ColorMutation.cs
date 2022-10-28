using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class ColorMutation
{
    private readonly IMapper _mapper;
    private readonly IColorData _colorData;

    public ColorMutation(IMapper mapper, IColorData colorData)
    {
        _mapper = mapper;
        _colorData = colorData;
    }
    public async Task<Color?> AddColorAsync(string name)
    {
        var createColorDto = await _colorData.CreateColor(name);
        return _mapper.Map<Color>(createColorDto);
    }

    public async Task<Color?> UpdateColorAsync(int id, string name)
    {
        var updateColorDto = await _colorData.UpdateColor(id, name);
        return _mapper.Map<Color>(updateColorDto);
    }
}
