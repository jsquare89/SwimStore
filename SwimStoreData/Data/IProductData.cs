using SwimStoreData.Models;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<ProductModel> GetProductById(int id);
    Task<IEnumerable<ProductModel>> GetProducts();
}