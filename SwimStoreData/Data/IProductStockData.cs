using SwimStoreData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;
public interface IProductStockData
{
    Task<ProductStockDto?> GetUniqueProduct(int productId, int sizeId, int colorId);
    Task<IEnumerable<ProductStockDto>> GetAllProductWithColor(int productId, int colorId);
    Task<IEnumerable<ProductStockDto>> GetAllProductsStock();
    Task<ProductStockDto> UpdateProductStock(int product_id, int size_id, int color_id, int quantity);
    Task<ProductStockDto> UpdateProductStockQuantity(int product_id, int size_id, int color_id, int quantity);
}
