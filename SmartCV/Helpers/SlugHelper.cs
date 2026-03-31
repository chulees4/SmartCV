using System.Text.RegularExpressions;

namespace SmartCV.Helpers;

public static class SlugHelper
{
    public static string Slugify(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return "";
        text = text.Trim().ToLowerInvariant();
        text = RemoveDiacritics(text);
        text = Regex.Replace(text, @"[^a-z0-9\s-]", "");
        text = Regex.Replace(text, @"\s+", "-");
        text = Regex.Replace(text, @"-+", "-");
        return text.Trim('-');
    }

    private static string RemoveDiacritics(string text)
    {
        var map = new Dictionary<string, string>
        {
            {"à|á|ả|ã|ạ|ă|ắ|ặ|ằ|ẳ|ẵ|â|ấ|ầ|ẩ|ẫ|ậ", "a"},
            {"è|é|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ", "e"},
            {"ì|í|ỉ|ĩ|ị", "i"},
            {"ò|ó|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ", "o"},
            {"ù|ú|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự", "u"},
            {"ỳ|ý|ỷ|ỹ|ỵ", "y"},
            {"đ", "d"}
        };
        foreach (var (pattern, replacement) in map)
            text = Regex.Replace(text, pattern, replacement);
        return text;
    }
}
