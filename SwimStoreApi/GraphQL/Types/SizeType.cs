using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.Types;

public class SizeType : ObjectType<Size>
{
    protected override void Configure(IObjectTypeDescriptor<Size> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Description("Represents a size of product in the store.");
    }
}
