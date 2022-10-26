namespace SwimStoreApi.GraphQL.ProductStocks;

public record AddProductStockInput(int ProductId, int SizeId, int ColorId, int Quantity);
