using Dapper;
using SwimStoreData.Models;
using System.ComponentModel;
using System.Reflection;

namespace SwimStoreApi;

public static class DapperMapping
{
    public static void Map()
    {
        // custom mapping
        var map = new CustomPropertyTypeMap(typeof(Product),
                                            (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));
        
        Dapper.SqlMapper.SetTypeMap(typeof(Product), map);
    }
    private static string GetDescriptionFromAttribute(MemberInfo member)
    {
        if (member == null) return null;

        var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
        return attrib == null ? null : attrib.Description;
    }
}
