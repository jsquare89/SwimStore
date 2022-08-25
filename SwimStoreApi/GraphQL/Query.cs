using SwimStoreData.Data;
using SwimStoreData.Models;

namespace SwimStoreApi.GraphQL;

public class Query
{
    public Query()
    {
    }

    [UseFiltering]
    public async Task<IEnumerable<ProductModel>> GetProduct([Service]IProductData productData)
    {
        return await productData.GetProducts();
    }
}
