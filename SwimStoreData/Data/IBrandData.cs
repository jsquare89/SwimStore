using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IBrandData
{
    Task<BrandDto?> GetBrandById(int id);
    Task<IEnumerable<BrandDto>> GetBrands();
    Task<dynamic> CreateBrand<T>(T parameters);
    Task<dynamic> UpdateBrand<T>(T parameters);
}
