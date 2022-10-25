using Microsoft.Extensions.Logging;
using Serilog;
using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;
using System.Reflection;
using System.Xml.Linq;

namespace SwimStoreData.Data;

public class ProductData : IProductData
{
    private readonly IPostgresqlDataAccess _db;

    public ProductData(IPostgresqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ProductDto>> GetProducts()
    {
        string getAllProductsQuery = "SELECT * FROM public.product ORDER BY id ASC ";
        return _db.LoadDataWithSql<ProductDto, dynamic>(getAllProductsQuery,new { });
    }

    public async Task<IEnumerable<ProductDto>> GetProductsBrands()
    {
        string getAllProductsQuery = "SELECT * FROM public.product ";
        string getAllBrandsQuery = "SELECT * from public.brand";

        var products = await _db.LoadDataWithSql<ProductDto, dynamic>(getAllProductsQuery, new {});
        var brands = await _db.LoadDataWithSql<BrandDto, dynamic>(getAllBrandsQuery, new {});
        foreach(var product in products)
        {
            product.Brand = new BrandDto()
            {
                id = product.BrandId,
                Name = brands.Where(b => b.id == product.BrandId).FirstOrDefault().Name
            };
        }
        return products;
    }

    public async Task<ProductDto?> GetProductById(int id)
    {
        string getProductByIdQuery = "SELECT * FROM public.product WHERE product.id = @id";
        var products = await _db.LoadDataWithSql<ProductDto, dynamic>(getProductByIdQuery, new { id });
        return products.FirstOrDefault();
    }

    public Task<IEnumerable<ProductDto>> GetProductsByBrand(string brand)
    {
        string getAllProductsByBrandQuery =
           "SELECT * \n" +
           "FROM product\n" +
           "Where brand = @brand";
        return _db.LoadDataWithSql<ProductDto, dynamic>(getAllProductsByBrandQuery, new { brand = brand });
    }

    public async Task<dynamic> CreateProduct<T>(T parameters)
    {
        string insertProductQuery = 
            "INSERT INTO product (name, original_price, current_price, quantity_in_stock, brand, gender)\n" +
            "VALUES (@name, @original_price, @current_price, @quantity_in_stock, @brand, @gender)\n" +
            "RETURNING *";
        var result = await _db.SaveDataWithSql<dynamic>(insertProductQuery, parameters);
        return result;
    }

    public async Task<dynamic> UpdateProduct<T>(T parameters)
    {
        string insertProductQuery = 
            "Update product\n" +
            "SET name = @name, original_price = @original_price, current_price = @current_price, quantity_in_stock = @quantity_in_stock, brand = @brand, gender = @gender\n" +
            "WHERE id = @id \n" +
            "RETURNING *";
        var result = await _db.SaveDataWithSql<dynamic>(insertProductQuery, parameters);
        return result;
    }
}
