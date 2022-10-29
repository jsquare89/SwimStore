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

    //TODO : Error handling, unknowck ids and insert if already exists
    public async Task<ProductStockDto> UpdateProductStock(int product_id, int size_id, int color_id, int quantity)
    {
        var parameters = new 
        {
            product_id,
            size_id,
            color_id,
            quantity
        };

        if (await UniqueProductStockExists(product_id, size_id, color_id))
        {
            return await UpdateProductStock(parameters);
        }
        return await CreateProductStock(parameters);
    }

    private async Task<ProductStockDto> CreateProductStock(dynamic parameters)
    {
        string insertProductStockQuery = "INSERT INTO public.product_stock(product_id, size_id, color_id, quantity)" +
            "\nVALUES (@product_id, @size_id, @color_id, @quantity)" +
            "\nRETURNING *";
        var productStockDto = await _db.SaveDataWithSqlAsync<ProductStockDto, dynamic>(insertProductStockQuery, parameters);
        return productStockDto;
    }

    public async Task<ProductStockDto> CreateProductStockAsync(int product_id, int size_id, int color_id, int quantity)
    {
        var parameters = new
        {
            product_id,
            size_id,
            color_id,
            quantity
        };
        string insertProductStockQuery = "INSERT INTO public.product_stock(product_id, size_id, color_id, quantity)" +
            "\nVALUES (@product_id, @size_id, @color_id, @quantity)" +
            "\nRETURNING *";
        var productStockDto = await _db.SaveDataWithSqlAsync<ProductStockDto, dynamic>(insertProductStockQuery, parameters);
        return productStockDto;
    }

    private async Task<ProductStockDto> UpdateProductStock(dynamic parameters)
    {
        string insertProductStockQuery = "UPDATE public.product_stock SET quantity = @quantity" +
            "\nWHERE product_id = @product_id AND size_id = @size_id AND color_id = @color_id" +
            "\nRETURNING *";
        var productStockDto = await _db.SaveDataWithSqlAsync<ProductStockDto, dynamic>(insertProductStockQuery, parameters);
        return productStockDto;
    }

    public async Task<ProductStockDto> UpdateProductStockQuantity(int product_id, int size_id, int color_id, int quantity)
    {
        var parameters = new
        {
            product_id,
            size_id,
            color_id,
            quantity
        };
        string insertProductStockQuery = "UPDATE public.product_stock "+
                                         "\nSET quantity = @quantity" +
                                         "\nWHERE product_id = @product_id AND size_id = @size_id AND color_id = @color_id" + 
                                         "\nRETURNING *";
        var productStockDto = await _db.SaveDataWithSqlAsync<ProductStockDto, dynamic>(insertProductStockQuery, parameters);
        return productStockDto;
    }

    public async Task<IEnumerable<ProductStockDto>> GetAllProductsStock()
    {
        string selectProductStockQuery = "SELECT * FROM public.product_stock ORDER BY product_id ASC ";
        var productStockDtos = await _db.LoadDataWithSqlAsync<ProductStockDto, dynamic>(selectProductStockQuery, new { });
        return productStockDtos;
    }

    public Task<IEnumerable<ProductStockDto>> GetAllProductWithColor(int productId, int colorId)
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

    private async Task<bool> UniqueProductStockExists(int product_id, int size_id, int color_id)
    {
        var productStockExistsQuery = "SELECT EXISTS(SELECT 1 from product_stock WHERE product_id = @product_id AND size_id = @size_id AND color_id = @color_id)";
        var parameters = new
        {
            product_id,
            size_id,
            color_id
        };
        var result = await _db.LoadDataWithSqlAsync<bool, dynamic>(productStockExistsQuery, parameters);
        return result.FirstOrDefault();
    }
}
