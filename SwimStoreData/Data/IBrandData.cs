using SwimStoreData.Models;

namespace SwimStoreData.Data;
public interface IBrandData
{
    Task<BrandModel?> GetBrandById(int id);
    Task<IEnumerable<BrandModel>> GetBrands();
    Task<dynamic> CreateBrand<T>(T parameters);
    Task<dynamic> UpdateBrand<T>(T parameters);
}
