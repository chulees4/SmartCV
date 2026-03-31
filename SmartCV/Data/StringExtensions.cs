using System.Text.RegularExpressions;

namespace SmartCV.Data;

public static class StringExtensions
{
    /// <summary>Converts "PascalCase" → "pascal_case" for PostgreSQL naming convention.</summary>
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var result = Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2");
        return result.ToLowerInvariant();
    }
}
