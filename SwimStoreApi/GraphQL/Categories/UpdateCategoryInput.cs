namespace SwimStoreApi.GraphQL.Categories;

public record UpdateCategoryInput(int Id,
                                  string Name,
                                  bool Accessory);
