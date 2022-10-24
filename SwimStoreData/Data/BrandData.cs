using SwimStoreData.DataAccess;
using SwimStoreData.Models;
using System;
using System.Collections.Generic;
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
    public Task<dynamic> CreateBrand<T>(T parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<BrandModel?> GetBrandById(int id)
    {
        string getBrandByIdQuery = "SELECT * FROM public.brand WHERE brand.id = @id";
        var brand = await _db.LoadDataWithSql<BrandModel, dynamic>(getBrandByIdQuery, new { id = id });
        return brand.FirstOrDefault();
    }

    public Task<IEnumerable<BrandModel>> GetBrands()
    {
        string getAllBrandsQuery = "SELECT * FROM public.brand ORDER BY id ASC ";
        return _db.LoadDataWithSql<BrandModel, dynamic>(getAllBrandsQuery, null);
    }

    public Task<dynamic> UpdateBrand<T>(T parameters)
    {
        throw new NotImplementedException();
    }
}
