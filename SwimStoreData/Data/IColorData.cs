using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IColorData
{
    Task<ColorDto> CreateColor<T>(T parameters);
    Task<ColorDto?> GetColorById(int id);
    Task<IEnumerable<ColorDto>> GetColors();
    Task<IEnumerable<ColorDto>> GetColorsByIds(IReadOnlyList<int> ids);
    Task<ColorDto> UpdateColor<T>(T parameters);
}