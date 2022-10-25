namespace SwimStoreApi.GraphQL.Products;

public record AddProductInput(string Name,
                              Int32 RetailPrice,
                              Int32 CurrentPrice,
                              string Description,
                              string Features,
                              string Sku,
                              string Gender,
                              Int32 BrandId,
                              Int32 CategoryId);
