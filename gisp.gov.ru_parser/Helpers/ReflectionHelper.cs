using System.Collections;
using System.Reflection;

namespace gisp.gov.ru_parser.Helpers
{
    public static class ReflectionHelper
    {
        public static Dictionary<string, object> GetAllPropertyValues(object obj, string parentPath = "")
        {
            var result = new Dictionary<string, object>();

            if (obj == null) return result;

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length > 0)
                    continue;

                string propertyName = property.Name;

                string fullPath = string.IsNullOrEmpty(parentPath) ? propertyName : $"{parentPath}.{propertyName}";

                object value;
                try
                {
                    value = property.GetValue(obj);
                }
                catch
                {
                    continue;
                }

                if (value == null)
                {
                    result[fullPath] = null;
                }
                else if (IsSimple(value.GetType()))
                {
                    result[fullPath] = value;
                }
                else if (value is IEnumerable enumerable && value is not string)
                {
                    int index = 0;
                    foreach (var item in enumerable)
                    {
                        if (!IsSimple(item.GetType()))
                        {
                            var subValues = GetAllPropertyValues(item, $"{fullPath}[{index}]");
                            foreach (var kv in subValues)
                                result[kv.Key] = kv.Value;
                        }
                        else
                        {
                            result[$"{parentPath}.{propertyName}[{index}]"] = item;
                        }
                        index++;
                    }
                }
                else
                {
                    var subValues = GetAllPropertyValues(value, fullPath);
                    foreach (var kv in subValues)
                        result[kv.Key] = kv.Value;
                }
            }

            return result;
        }

        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime)
                || type == typeof(Guid)
                || type == typeof(DateTimeOffset)
                || type == typeof(TimeSpan);
        }
    }

}
