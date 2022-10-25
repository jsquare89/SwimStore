using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface ICategoryData
{
    Task<CategoryDto?> GetCategoryById(int id);
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<dynamic> CreateCategory<T>(T parameters);
    Task<dynamic> UpdateCategory<T>(T parameters);
}
