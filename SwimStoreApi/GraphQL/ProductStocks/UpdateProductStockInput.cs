namespace SwimStoreApi.GraphQL.ProductStocks;

public record UpdateProductStockInput(int ProductId, int SizeId, int ColorId, int Quantity);
