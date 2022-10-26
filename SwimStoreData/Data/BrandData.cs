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
    public async Task<BrandDto> CreateBrand(string name)
    {
        var insertBrandQuery = "INSERT INTO brand(name) VALUES (@name)\n" +
                               "RETURNING *";
        var parameters = new
        {
            name = name
        };
        var brand = await _db.SaveDataWithSqlAsync<BrandDto, dynamic>(insertBrandQuery, parameters);
        return brand;
    }

    public async Task<BrandDto> UpdateBrand(int id, string name)
    {
        var updateBrandQuery = "UPDATE brand SET name=@name WHERE id = @id \n" +
                               "RETURNING *";
        var parameters = new
        {
            id = id,
            name = name
        };
        var brand = await _db.SaveDataWithSqlAsync<BrandDto, dynamic>(updateBrandQuery, parameters);
        return brand;
    }

    public async Task<BrandDto?> GetBrandById(int id)
    {
        string getBrandByIdQuery = "SELECT * FROM public.brand WHERE brand.id = @id";
        var brand = await _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getBrandByIdQuery, new { id = id });
        return brand.FirstOrDefault();
    }

    public async Task<IEnumerable<BrandDto>> GetBrands()
    {
        string getAllBrandsQuery = "SELECT * FROM public.brand ORDER BY id ASC ";
        var brands =  await _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getAllBrandsQuery, new { });
        return brands;
    }

    public async Task<IEnumerable<BrandDto>> GetBrandsByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",",ids);
        string getBrandsByIds = $"SELECT id, name FROM public.brand where id in ({commaSeperatedIds})";
        var brands = await _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getBrandsByIds, new { });
        return brands;
    }
}
