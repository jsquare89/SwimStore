﻿using SwimStoreData.DataAccess;
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
    public Task<dynamic> CreateCategory<T>(T parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        string getAllCategoriesQuery = "SELECT * FROM public.category ORDER BY id ASC ";
        return await _db.LoadDataWithSql<CategoryDto, dynamic>(getAllCategoriesQuery, new { });
    }

    public async Task<CategoryDto?> GetCategoryById(int id)
    {
        string getCategoryByIdQuery = "SELECT * FROM public.category WHERE category.id = @id";
        var category = await _db.LoadDataWithSql<CategoryDto, dynamic>(getCategoryByIdQuery, new { id = id });
        return category.FirstOrDefault();
    }

    public Task<dynamic> UpdateCategory<T>(T parameters)
    {
        throw new NotImplementedException();
    }
}
