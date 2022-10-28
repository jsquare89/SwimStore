using AutoMapper;
using Npgsql.PostgresTypes;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Mutations;
[ExtendObjectType(typeof(Mutation))]
public class ProductMutation
{
	private readonly IMapper _mapper;
	private readonly IProductData _productData;

	public ProductMutation(IMapper mapper, IProductData productData)
	{
		_mapper = mapper;
		_productData = productData;
	}

    public async Task<Product?> AddProductAsync(
        string name,                 
        int retailPrice,              
        int currentPrice,
        string description,
        string features,
        string sku,
        int brandId,
        int categoryId,
        string gender)
    {
        var createdProductDto = await _productData.CreateProduct(
            name, 
            retailPrice, 
            currentPrice,
            description, 
            features, 
            sku, 
            brandId, 
            categoryId, 
            gender);

        return _mapper.Map<Product>(createdProductDto);
    }

    public async Task<Product?> UpdateProductAsync(
        int id,
        string name,
        int retailPrice,
        int currentPrice,
        string description,
        string features,
        string sku,
        int brandId,
        int categoryId,
        string gender)
    {
        var updatedProductDto = await _productData.UpdateProduct(
            id,
            name,
            retailPrice,
            currentPrice,
            description,
            features, 
            sku,
            brandId,
            categoryId,
            gender);

        return _mapper.Map<Product>(updatedProductDto);
    }
}
