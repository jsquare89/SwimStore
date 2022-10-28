using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.Types;

public class CategoryType : ObjectType<Category>
{
    protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Description("Represents a category in the store.");
    }
}