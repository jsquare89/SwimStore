using Dapper;
using SwimStoreData.Dtos;
using System.ComponentModel;
using System.Reflection;

namespace SwimStoreApi.MapperProfiles;

public static class DapperMapping
{
    public static void Map()
    {
        // custom mapping
        var map = new CustomPropertyTypeMap(typeof(ProductDto),
                                            (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));

        SqlMapper.SetTypeMap(typeof(ProductDto), map);
    }
    private static string GetDescriptionFromAttribute(MemberInfo member)
    {
        if (member == null) return null;

        var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
        return attrib == null ? null : attrib.Description;
    }
}
