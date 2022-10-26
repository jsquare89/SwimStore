using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;
public class ProductStockData : IProductStockData
{
    private readonly IPostgresqlDataAccess _db;

    public ProductStockData(IPostgresqlDataAccess db)
    {
        _db = db;
    }
    public async Task<IEnumerable<ProductStockDto>> GetAllProductsStock()
    {
        string getAllProductStockQuery = "SELECT * FROM public.product_stock ORDER BY product_id ASC ";
        var productStockDtos = await _db.LoadDataWithSqlAsync<ProductStockDto, dynamic>(getAllProductStockQuery, new { });
        return productStockDtos;
    }

    public Task<IEnumerable<ProductStockDto>?> GetAllProductWithColor(int productId, int colorId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductStockDto?> GetUniqueProduct(int productId, int sizeId, int colorId)
    {
        var paramenters = new
        {
            product_id = productId,
            size_id = sizeId,
            color_id = colorId
        };
        string selectUniqueProductQuery = "SELECT * FROM public.product_stock WHERE product_id = @product_id, size_id = @size_id, color_id = @color_id";
        var uniqueProduct = await _db.LoadDataWithSqlAsync<ProductStockDto, dynamic>(selectUniqueProductQuery, paramenters);
        return uniqueProduct.FirstOrDefault();
    }
}
