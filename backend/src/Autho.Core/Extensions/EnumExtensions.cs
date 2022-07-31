using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autho.Principal
{
    public static class EnumExtensions
    {
        public static string? GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType()
                .GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
        }

        public static string? GetEnumDisplayDescription(this Enum enumType)
        {
            return enumType.GetType()
                .GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetDescription();
        }
    }
}
