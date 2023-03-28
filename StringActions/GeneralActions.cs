using System.Text;

namespace StringActions
{
    public class GeneralActions
    {
        public static bool IsStringPalindrom(string i_Str)
        {
            int length = i_Str.Length;
            if (length == 0 || length == 1)
            {
                return true;
            }
            StringBuilder sb = new StringBuilder(i_Str, length);
            sb.Remove(length - 1, 1);
            sb.Remove(0, 1);
            bool resultFromReccursion = IsStringPalindrom(sb.ToString());
            bool currentCheck = (i_Str[0] == i_Str[length - 1]);
            return (resultFromReccursion && currentCheck);
        }
    }
}
