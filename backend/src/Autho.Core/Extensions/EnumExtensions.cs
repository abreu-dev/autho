using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autho.Core.Extensions
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

        public static T? GetEnumValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var itemEnum = (T)item;

                if (itemEnum != null)
                {
                    var itemEnumDescription = itemEnum.GetEnumDisplayDescription();
                    if (itemEnumDescription == description)
                    {
                        return itemEnum;
                    }
                }
            }

            return default;
        }
    }
}
