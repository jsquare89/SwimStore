namespace SwimStoreApi.GraphQL.Products;

public record AddProductInput(string Name,
                              int OriginalPrice,
                              int CurrentPrice,
                              int QuantityInStock,
                              string Brand,
                              string Gender);
