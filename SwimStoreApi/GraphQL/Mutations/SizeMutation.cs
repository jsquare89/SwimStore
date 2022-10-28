using AutoMapper;
using SwimStoreApi.GraphQL.Types;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class SizeMutation
{
    private readonly IMapper _mapper;
    private readonly ISizeData _sizeData;

    public SizeMutation(IMapper mapper, ISizeData sizeData)
    {
        _mapper = mapper;
        _sizeData = sizeData;
    }
    public async Task<Size?> AddSizeAsync(string name, string gender)
    {
        var createSizeDto = await _sizeData.CreateSize(name, gender);
        return _mapper.Map<Size>(createSizeDto);
    }

    public async Task<Size?> UpdateSizeAsync(int id, string name, string gender)
    {
        var createSizeDtos = await _sizeData.UpdateSize(id, name, gender);
        return _mapper.Map<Size>(createSizeDtos);
    }
}
