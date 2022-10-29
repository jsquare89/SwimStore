using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;
using HotChocolate.AspNetCore.Authorization;

namespace SwimStoreApi.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class ProductStockQuery
{
	private readonly IMapper _mapper;

	public ProductStockQuery(IMapper mapper)
	{
		_mapper = mapper;
	}

    
    [UseFiltering]
    public async Task<IEnumerable<ProductStock>> GetProductStocks([Service] IProductStockData productStockData)
    {
        var productStocks = await productStockData.GetAllProductsStock();
        return _mapper.Map<IEnumerable<ProductStock>>(productStocks);
    }
}
