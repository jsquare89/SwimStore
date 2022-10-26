using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IBrandData
{
    Task<BrandDto?> GetBrandById(int id);
    Task<IEnumerable<BrandDto>> GetBrandsByIds(IReadOnlyList<int> ids);
    Task<IEnumerable<BrandDto>> GetBrands();
    Task<BrandDto> CreateBrand(string name);
    Task<BrandDto> UpdateBrand(int id, string name);
}
