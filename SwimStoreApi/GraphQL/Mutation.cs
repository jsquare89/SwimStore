using SwimStoreApi.GraphQL.Products;
using SwimStoreApi.Models;
using SwimStoreData.Data;
using SwimStoreData.Models;

namespace SwimStoreApi.GraphQL;

public class Mutation
{
    public async Task<AddProductPayload> AddProductAsync(AddProductInput input,
        [Service] IProductData productData)
    {
        var parameters = new
        {
            name = input.Name,
            original_price = input.OriginalPrice,
            current_price = input.CurrentPrice,
            quantity_in_stock = input.QuantityInStock,
            brand = input.Brand,
            gender = input.Gender
        };

        var obj = await productData.CreateProduct(parameters);
        var product = new Product
        {
            Id = obj.id,
            Name = obj.name,
            OriginalPrice = obj.original_price,
            CurrentPrice = obj.current_price,
            QuantityInStock = obj.quantity_in_stock,
            Brand = obj.brand,
            Gender = obj.gender
        };
        
        return new AddProductPayload(product);
    }
    public async Task<UpdateProductPayload> UpdateProductAsync(UpdateProductInput input,
        [Service] IProductData productData)
    {
        var parameters = new
        {
            id = input.id,
            name = input.Name,
            original_price = input.OriginalPrice,
            current_price = input.CurrentPrice,
            quantity_in_stock = input.QuantityInStock,
            brand = input.Brand,
            gender = input.Gender
        };

        var obj = await productData.UpdateProduct(parameters);
        var product = new Product
        {
            Id = obj.id,
            Name = obj.name,
            OriginalPrice = obj.original_price,
            CurrentPrice = obj.current_price,
            QuantityInStock = obj.quantity_in_stock,
            Brand = obj.brand,
            Gender = obj.gender
        };

        return new UpdateProductPayload(product);
    }

}
