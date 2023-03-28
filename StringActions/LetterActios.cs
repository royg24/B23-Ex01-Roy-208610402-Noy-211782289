
namespace StringActions
{
    public class LetterActions
    {
        public static int CountUpperCaseInStr(string i_Str)
        {
            int count = 0, length = i_Str.Length;
            for (int i = 0; i < length; i++)
            {
                if (char.IsUpper(i_Str[i]) == true)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
