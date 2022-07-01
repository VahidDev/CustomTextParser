namespace CustomTxtParser.Extensions
{
    public static class StringExtensions
    {
        public static bool IsLastIndex(this string str, int currentIndex)
        {
            return currentIndex == str.Length - 1;
        }

        public static bool IsSubStrEqualToSpecificStr(this string str, int index, string specificStr)
        {
            return str.Substring(index, specificStr.Length) == specificStr;
        }
    }
}
