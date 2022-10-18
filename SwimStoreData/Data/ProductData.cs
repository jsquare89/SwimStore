using Microsoft.Extensions.Logging;
using Serilog;
using SwimStoreData.DataAccess;
using SwimStoreData.Models;
using System.Reflection;
using System.Xml.Linq;

namespace SwimStoreData.Data;

public class ProductData : IProductData
{
    private readonly IPostgresqlDataAccess _db;
    private readonly ILogger<ProductData> _logger;

    public ProductData(IPostgresqlDataAccess db, ILogger<ProductData> logger)
    {
        _db = db;
        _logger = logger;
    }

    public Task<IEnumerable<ProductModel>> GetProducts()
    {
        string getAllProductsSF = "sf_product_get_all";
        return _db.LoadDataWithFunction<ProductModel, dynamic>(getAllProductsSF, new { });
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        var products = await _db.LoadDataWithFunction<ProductModel, dynamic>("sf_product_get_by_id", new { id });
        return products.FirstOrDefault();
    }

    public Task<IEnumerable<ProductModel>> GetProductsByBrand(string brand)
    {
        string getAllProductsByBrandQuery =
           "SELECT * \n" +
           "FROM product\n" +
           "Where brand = @brand";
        return _db.LoadDataWithSql<ProductModel, dynamic>(getAllProductsByBrandQuery, new { brand = brand });
    }

    public async Task<dynamic> CreateProduct<T>(T parameters)
    {
        string insertProductQuery = "INSERT INTO product (name, original_price, current_price, quantity_in_stock, brand, gender)\n" +
                                    "VALUES (@name, @original_price, @current_price, @quantity_in_stock, @brand, @gender)\n" +
                                    "RETURNING *";
        var result = await _db.SaveDataWithSql<dynamic>(insertProductQuery, parameters);
        return result;
    }

    public async Task<dynamic> UpdateProduct<T>(T parameters)
    {
        string insertProductQuery = "Update product\n" +
                                    "SET name = @name, original_price = @original_price, current_price = @current_price, quantity_in_stock = @quantity_in_stock, brand = @brand, gender = @gender\n" +
                                    "WHERE id = @id \n" +
                                    "RETURNING *";
        var result = await _db.SaveDataWithSql<dynamic>(insertProductQuery, parameters);
        return result;
    }
}
