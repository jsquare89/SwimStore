namespace SwimStoreApi.GraphQL.Products;

public record UpdateProductInput(int id,
                                 string Name,
                                 int OriginalPrice,
                                 int CurrentPrice,
                                 int QuantityInStock,
                                 string Brand,
                                 string Gender);
