using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;
public class BrandData : IBrandData
{
    private readonly IPostgresqlDataAccess _db;

    public BrandData(IPostgresqlDataAccess db)
    {
        _db = db;
    }
    public async Task<BrandDto> CreateBrand<T>(T parameters)
    {
        var insertBrandQuery = "INSERT INTO brand(name) VALUES (@name)\n" +
                               "RETURNING *";
        var brand = await _db.SaveDataWithSqlAsync<BrandDto, T>(insertBrandQuery, parameters);
        return brand;
    }

    public async Task<BrandDto> UpdateBrand<T>(T parameters)
    {
        var updateBrandQuery = "UPDATE brand SET name=@name WHERE id = @id \n" +
                               "RETURNING *";
        var brand = await _db.SaveDataWithSqlAsync<BrandDto, T>(updateBrandQuery, parameters);
        return brand;
    }

    public async Task<BrandDto?> GetBrandById(int id)
    {
        string getBrandByIdQuery = "SELECT * FROM public.brand WHERE brand.id = @id";
        var brand = await _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getBrandByIdQuery, new { id = id });
        return brand.FirstOrDefault();
    }

    public Task<IEnumerable<BrandDto>> GetBrands()
    {
        string getAllBrandsQuery = "SELECT * FROM public.brand ORDER BY id ASC ";
        return _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getAllBrandsQuery, new { });
    }

    public Task<IEnumerable<BrandDto>> GetBrandsByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",",ids);
        string getBrandsByIds = $"SELECT id, name FROM public.brand where id in ({commaSeperatedIds})";
        return _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getBrandsByIds, new { });
    }
}
