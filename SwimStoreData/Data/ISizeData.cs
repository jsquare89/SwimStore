using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface ISizeData
{
    Task<SizeDto> CreateSize(string name, string gender);
    Task<SizeDto?> GetSizeById(int id);
    Task<IEnumerable<SizeDto>> GetSizes();
    Task<IEnumerable<SizeDto>> GetSizesByIds(IReadOnlyList<int> ids);
    Task<SizeDto> UpdateSize(int id, string name, string gender);
}