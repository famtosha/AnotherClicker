public static class StringExtentions
{
    public static string MoveLeft(this string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        text = text.Remove(0, 1);
        return text;
    }
}
