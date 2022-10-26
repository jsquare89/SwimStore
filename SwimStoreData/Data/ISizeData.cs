using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface ISizeData
{
    Task<SizeDto> CreateSize<T>(T parameters);
    Task<SizeDto?> GetSizeById(int id);
    Task<IEnumerable<SizeDto>> GetSizes();
    Task<IEnumerable<SizeDto>> GetSizesByIds(IReadOnlyList<int> ids);
    Task<SizeDto> UpdateSize<T>(T parameters);
}