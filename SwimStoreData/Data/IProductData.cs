using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public interface IProductData
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto?> GetProductById(int id);
    Task<IEnumerable<ProductDto>> GetProductsByIds(IReadOnlyList<int> ids);
    Task<IEnumerable<ProductDto>> GetProductsByBrand(string brand);
    Task<IEnumerable<ProductDto>> GetProductsBrands();
    Task<ProductDto> CreateProduct(string name, 
                                   int retailPrice, 
                                   int currentPrice, 
                                   string desctiption, 
                                   string features, 
                                   string sku, 
                                   int brandId, 
                                   int categoryId, 
                                   string gender);
    Task<ProductDto> UpdateProduct(int id, 
                                   string name, 
                                   int retailPrice, 
                                   int currentPrice, 
                                   string desctiption, 
                                   string features, 
                                   string sku, 
                                   int brandId, 
                                   int categoryId, 
                                   string gender);
}