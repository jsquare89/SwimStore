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
        return _db.LoadDataWithSqlAsync<ProductDto, dynamic>(getAllProductsQuery,new { });
    }

    public async Task<IEnumerable<ProductDto>> GetProductsBrands()
    {
        string getAllProductsQuery = "SELECT * FROM public.product ";
        string getAllBrandsQuery = "SELECT * from public.brand";

        var products = await _db.LoadDataWithSqlAsync<ProductDto, dynamic>(getAllProductsQuery, new {});
        var brands = await _db.LoadDataWithSqlAsync<BrandDto, dynamic>(getAllBrandsQuery, new {});
        foreach(var product in products)
        {
            product.Brand = new BrandDto()
            {
                Id = product.BrandId,
                Name = brands.Where(b => b.Id == product.BrandId).FirstOrDefault().Name
            };
        }
        return products;
    }

    public async Task<ProductDto?> GetProductById(int id)
    {
        string getProductByIdQuery = "SELECT * FROM public.product WHERE product.id = @id";
        var products = await _db.LoadDataWithSqlAsync<ProductDto, dynamic>(getProductByIdQuery, new { id });
        return products.FirstOrDefault();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByIds(IReadOnlyList<int> ids)
    {
        var parameters = string.Join(",", ids);
        string getProductByIdQuery = $"SELECT * FROM public.product WHERE product.id in ({parameters})";
        var products = await _db.LoadDataWithSqlAsync<ProductDto, dynamic>(getProductByIdQuery, new { });
        return products;
    }

    public Task<IEnumerable<ProductDto>> GetProductsByBrand(string brand)
    {
        string getAllProductsByBrandQuery =
           "SELECT * \n" +
           "FROM product\n" +
           "Where brand = @brand";
        var results = _db.LoadDataWithSqlAsync<ProductDto, dynamic>(getAllProductsByBrandQuery, new { brand = brand });
        return results;
    }

    public async Task<ProductDto> CreateProduct(string name, int retailPrice, int currentPrice,
        string desctiption, string features, string sku, int brandId, int categoryId, string gender)
    {
        string insertProductQuery = 
            "INSERT INTO product (name, retail_price, current_price, description, features, sku, brand_id, category_id, gender)\n" +
            "VALUES (@name, @retail_price, @current_price, @description, @features, @sku, @brand_id, @category_id, @gender)\n" +
            "RETURNING *";

        var parameters = new
        {
            name = name,
            retail_price = retailPrice,
            current_price = currentPrice,
            description = desctiption,
            features = features,
            sku = sku,
            brand_id = brandId,
            category_id = categoryId,
            gender = gender
        };
        var result = await _db.SaveDataWithSqlAsync<ProductDto, dynamic>(insertProductQuery, parameters);
        return result;
    }

    public async Task<ProductDto> UpdateProduct(int id, string name, int retailPrice, int currentPrice,
        string desctiption, string features, string sku, int brandId, int categoryId, string gender)
    {
        string updateProductQuery = 
            "Update product\n" +
            "SET name = @name, retail_price = @retail_price, current_price = @current_price, description = @description, features = @features, sku = @sku, brand_id = @brand_id, category_id = @category_id, gender = @gender\n" +
            "WHERE id = @id \n" +
            "RETURNING *";
        var parameters = new
        {
            id = id,
            name = name,
            retail_price = retailPrice,
            current_price = currentPrice,
            description = desctiption,
            features = features,
            sku = sku,
            brand_id = brandId,
            category_id = categoryId,
            gender = gender
        };
        var result = await _db.SaveDataWithSqlAsync<ProductDto, dynamic>(updateProductQuery, parameters);
        return result;
    }
}
