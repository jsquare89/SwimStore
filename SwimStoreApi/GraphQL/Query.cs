using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;
using SwimStoreData.Dtos;

namespace SwimStoreApi.GraphQL;

public class Query
{
    private readonly IMapper _mapper;

    public Query(IMapper mapper)
    {
        _mapper = mapper;
    }

    [UseFiltering]
    public async Task<IEnumerable<Product>> GetProduct([Service]IProductData productData)
    {
        var products = await productData.GetProducts();
        return _mapper.Map<IEnumerable<Product>>(products);
    }


    [UseFiltering]
    public async Task<IEnumerable<Product>> GetProductBrands([Service] IProductData productData)
    {
        var products = await productData.GetProductsBrands();
        return _mapper.Map<IEnumerable<Product>>(products );
    }

    [UseFiltering]
    public async Task<Product?> GetProductById(Int32 id, [Service] IProductData productData)
    {
        var product = await productData.GetProductById(id);
        return _mapper.Map<Product>(product);
    }

    [UseFiltering]
    public async Task<IEnumerable<Product>> GetProductByBrand(string brand, [Service] IProductData productData)
    {
        if (brand == null)
        {
            return Enumerable.Empty<Product>();
        }
        var products = await productData.GetProductsByBrand(brand);
        return _mapper.Map<IEnumerable<Product>>(products);
    }

    [UseFiltering]
    public async Task<IEnumerable<Brand>> GetBrands([Service] IBrandData brandData)
    {
        var brands = await brandData.GetBrands();
        return _mapper.Map<IEnumerable<Brand>>(brands);
    }

    [UseFiltering]
    public async Task<Brand?> GetBrandById(Int32 id, [Service] IBrandData brandData)
    {
        var brand = await brandData.GetBrandById(id);
        return _mapper.Map<Brand>(brand);
    }

    [UseFiltering]
    public async Task<IEnumerable<Category>> GetCategories([Service] ICategoryData categoryData)
    {
        var categories = await categoryData.GetCategories();
        return _mapper.Map<IEnumerable<Category>>(categories);
    }

    [UseFiltering]
    public async Task<Category?> GetCategoryById(Int32 id, [Service] ICategoryData categoryData)
    {
        var category = await categoryData.GetCategoryById(id);
        return _mapper.Map<Category>(category);
    }
}
