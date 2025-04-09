using AngleSharp.Dom;
using System.Text.RegularExpressions;

namespace gisp.gov.ru_parser.Helpers;

public static class ElementExtensions
{
    public static T? GetAttribute<T>(this IElement element, string selector, string attribute = "")
    {
        if (element == null)
            return default;

        var item = element;

        if (selector == "")
        {
            string res;

            if (attribute == "")
                res = item.TextContent.Trim();
            else
                res = item.GetAttribute(attribute) ?? "";

            return (T)Convert.ChangeType(res, typeof(T));
        }
        else
            item = element.QuerySelector(selector);

        if (item == null)
            return default;

        var result = item.GetAttribute(attribute);

        if (result == null)
            result = item.TextContent.Trim();

        try
        {
            Type typeOfT = typeof(T);

            if (typeOfT.IsGenericType && typeOfT.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                typeOfT = Nullable.GetUnderlyingType(typeOfT);
            }

            if (typeof(T) == typeof(decimal))
                result = Regex.Replace(result, @"[^0-9\,\.]", "").Replace(",", ".");

            if (typeof(T) == typeof(string))
            {
                string pattern = @"\s+";
                string replacement = " ";
                result = Regex.Replace(result, pattern, replacement);
            }

            if(string.IsNullOrEmpty(result))
                return default;

            return (T)Convert.ChangeType(result, typeOfT);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("An error occurred related to type convet: ", ex);
            return default;
        }
    }
}
