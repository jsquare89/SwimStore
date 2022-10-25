using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IBrandData
{
    Task<BrandDto?> GetBrandById(int id);
    Task<IEnumerable<BrandDto>> GetBrands();
    Task<BrandDto> CreateBrand<T>(T parameters);
    Task<BrandDto> UpdateBrand<T>(T parameters);
}
