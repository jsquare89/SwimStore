using SwimStoreApi.Models;

namespace SwimStoreApi.GraphQL.Types;

public class ColorType : ObjectType<Color>
{
    protected override void Configure(IObjectTypeDescriptor<Color> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Description("Represents a color of product in the store.");
    }
}
