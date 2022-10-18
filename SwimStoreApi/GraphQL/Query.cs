﻿using SwimStoreData.Data;
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

    [UseFiltering]
    public async Task<IEnumerable<ProductModel>> GetProductByBrand(string brand, [Service] IProductData productData)
    {
        return await productData.GetProductsByBrand(brand);
    }
}
