using System.ComponentModel;
using System.Reflection;
using Domain.Utils;

namespace Domain.utils;

public static class EnumExtensions
{
    public static string GetDescription(this ListRoles value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
}