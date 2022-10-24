using SwimStoreData.Models;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<ProductModel> GetProductById(int id);
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<ProductModel>> GetProductsByBrand(string brand);
    Task<dynamic> CreateProduct<T>(T parameters);
    Task<dynamic> UpdateProduct<T>(T parameters);
}