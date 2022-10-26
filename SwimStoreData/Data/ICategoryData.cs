using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface ICategoryData
{
    Task<CategoryDto?> GetCategoryById(int id);
    Task<IEnumerable<CategoryDto>> GetCategoriesByIds(IReadOnlyList<int> ids);
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<CategoryDto> CreateCategory(string name, bool accessory);
    Task<CategoryDto> UpdateCategory(int id, string name, bool accessory);
}
