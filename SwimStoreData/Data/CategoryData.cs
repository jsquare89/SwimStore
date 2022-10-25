using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;
public class CategoryData : ICategoryData
{
    private readonly IPostgresqlDataAccess _db;

    public CategoryData(IPostgresqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        string getAllCategoriesQuery = "SELECT * FROM public.category ORDER BY id ASC ";
        var categories = await _db.LoadDataWithSqlAsync<CategoryDto, dynamic>(getAllCategoriesQuery, new { });
        return categories;
    }
    public async Task<CategoryDto?> GetCategoryById(int id)
    {
        string getCategoryByIdQuery = "SELECT * FROM public.category WHERE category.id = @id";
        var category = await _db.LoadDataWithSqlAsync<CategoryDto, dynamic>(getCategoryByIdQuery, new { id = id });
        return category.FirstOrDefault();
    }
    public Task<IEnumerable<CategoryDto>> GetCategoriesByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",", ids);
        string getCategoriesByIdsQuery = $"SELECT id, name FROM public.category where id in ({commaSeperatedIds})";
        var categories =  _db.LoadDataWithSqlAsync<CategoryDto, dynamic>(getCategoriesByIdsQuery, new { });
        return categories;
    }
    public async Task<CategoryDto> CreateCategory<T>(T parameters)
    {
        var insertCategoryQuery = "INSERT INTO category(name, accessory) VALUES (@name, @accessory)\n" +
                               "RETURNING *";
        var category = await _db.SaveDataWithSqlAsync<CategoryDto, T>(insertCategoryQuery, parameters);
        return category;
    }
    public async Task<CategoryDto> UpdateCategory<T>(T parameters)
    {
        var updateCategoryQuery = "UPDATE category SET name=@name, accessory=@accessory WHERE id = @id \n" +
                              "RETURNING *";
        var brand = await _db.SaveDataWithSqlAsync<CategoryDto, T>(updateCategoryQuery, parameters);
        return brand;
    }
}
