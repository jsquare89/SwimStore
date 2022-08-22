using SwimStoreData.Models;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<IEnumerable<ProductModel>> GetProducts();
}