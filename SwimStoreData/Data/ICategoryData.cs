using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface ICategoryData
{
    Task<CategoryDto?> GetCategoryById(int id);
    Task<IEnumerable<CategoryDto>> GetCategoriesByIds(IReadOnlyList<int> ids);
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<CategoryDto> CreateCategory<T>(T parameters);
    Task<CategoryDto> UpdateCategory<T>(T parameters);
}
