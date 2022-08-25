using Microsoft.Extensions.Logging;
using Serilog;
using SwimStoreData.DataAccess;
using SwimStoreData.Models;

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
        string getAllProductsQuery = 
            "SELECT * \n" +
            "FROM product";
        _logger.LogInformation("SQL: \n{sqlQuery}", getAllProductsQuery);
        return _db.LoadDataWithSql<ProductModel, dynamic>(getAllProductsQuery, new { });
        //string functionQuery = "sf_product_get_all";
        //return _db.LoadDataWithFunction<ProductModel, dynamic>(procedureCall, new { });
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        var products = await _db.LoadDataWithFunction<ProductModel, dynamic>("sf_product_get_by_id", new { id });
        return products.FirstOrDefault();
    }

}
