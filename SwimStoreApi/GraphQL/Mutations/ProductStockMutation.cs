using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class ProductStockMutation
{
	private readonly IMapper _mapper;
	private readonly IProductStockData _productStockData;

	public ProductStockMutation(IMapper mapper, IProductStockData productStockData)
	{
		_mapper = mapper;
		_productStockData = productStockData;
	}

    public async Task<ProductStock?> AddProductStockAsync(int productId, int sizeId, int colorId, int quantity)
    {
        try
        {
            var productStockDto = await _productStockData.CreateProductStockAsync(productId, sizeId, colorId,quantity);
            return _mapper.Map<ProductStock>(productStockDto);

        }
        catch
        {
            throw new GraphQLException($"Could not add product stock. Ensure productId, sizeId, colorId are not in product stock already or use updateProductStock");
        }

    }

    public async Task<ProductStock?> UpdateProductStockQuantityAsync(int productId, int sizeId, int colorId, int quantity)
    {
        var productStockDto = await _productStockData.UpdateProductStockQuantity(productId, sizeId, colorId, quantity);

        return _mapper.Map<ProductStock>(productStockDto);
    }
}
