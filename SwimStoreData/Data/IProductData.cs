using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<ProductDto?> GetProductById(int id);
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<IEnumerable<ProductDto>> GetProductsByBrand(string brand);
    Task<dynamic> CreateProduct<T>(T parameters);
    Task<dynamic> UpdateProduct<T>(T parameters);
    Task<IEnumerable<ProductDto>> GetProductsBrands();
}