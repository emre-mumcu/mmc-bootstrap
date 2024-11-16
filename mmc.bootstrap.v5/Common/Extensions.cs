using System.Reflection;

namespace mmc.bootstrap.v5.Common;

public static class Extensions
{
    public static T? GetAttribute<T>(this Enum enumValue) where T : Attribute
    {
        var attributes = GetAttributes<T>(enumValue);
        if(attributes is null) return null;
        else return attributes[0];
    }

    public static T[]? GetAttributes<T>(this Enum enumValue) where T : Attribute
    {
        FieldInfo? fi = enumValue.GetType().GetField(enumValue.ToString());
        if(fi is null) return null;
        else return (T[])fi.GetCustomAttributes(typeof(T), false);                
    }
}
