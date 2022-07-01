namespace CustomTxtParser.Utilities.TransactionUtilities
{
    public class StringUtilitites
    {
        public static void AddSubStrToCollection
            (ICollection<string> items
            , string text
            , int startIndex
            , int? length)
        {
            if (length != null)
            {
                items.Add(text.Substring(startIndex, (int)length));
            }
            else
            {
                items.Add(text.Substring(startIndex));
            }
        }
    }
}
