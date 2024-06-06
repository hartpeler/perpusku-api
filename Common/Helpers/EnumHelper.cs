using System.Reflection;
using perpusku_api.Common.Classes;

namespace perpusku_api.Common.Helpers
{
    public static class EnumHelper
    {
        public static string[] GetStringValues<T>()
        {
            return Enum.GetValues(typeof(T))
                       .Cast<Enum>()
                       .Select(e => e.GetType().GetField(e.ToString())
                                     .GetCustomAttribute<StringValueAttribute>()?.Value)
                       .ToArray();
        }
    }
}
