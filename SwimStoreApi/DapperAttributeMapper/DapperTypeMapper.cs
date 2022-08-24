// Thanks to Kaleb Pederson/Cornelis for the mapper
// https://stackoverflow.com/questions/8902674/manually-map-column-names-with-class-properties/34856158#34856158
// https://stackoverflow.com/questions/20951531/dapper-with-attributes-mapping/20969521#20969521

using Dapper;

namespace SwimStoreApi.DapperAttributeMapper;

public static class DapperTypeMapper
{
    public static void Initialize(string @namespace)
    {
        var types = from assem in AppDomain.CurrentDomain.GetAssemblies().ToList()
                    from type in assem.GetTypes()
                    where type.IsClass && type.Namespace == @namespace
                    select type;

        types.ToList().ForEach(type =>
        {
            var mapper = (SqlMapper.ITypeMap)Activator
                .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                                .MakeGenericType(type));
            SqlMapper.SetTypeMap(type, mapper);
        });
    }
}
