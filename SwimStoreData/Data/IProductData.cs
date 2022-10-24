using SwimStoreData.Models;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<Product> GetProductById(int id);
    Task<IEnumerable<Product>> GetProducts();
    Task<IEnumerable<Product>> GetProductsByBrand(string brand);
    Task<dynamic> CreateProduct<T>(T parameters);
    Task<dynamic> UpdateProduct<T>(T parameters);
}