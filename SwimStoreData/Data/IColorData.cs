using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IColorData
{
    Task<ColorDto> CreateColor(string name);
    Task<ColorDto?> GetColorById(int id);
    Task<IEnumerable<ColorDto>> GetColors();
    Task<IEnumerable<ColorDto>> GetColorsByIds(IReadOnlyList<int> ids);
    Task<ColorDto> UpdateColor(int id, string name);
}