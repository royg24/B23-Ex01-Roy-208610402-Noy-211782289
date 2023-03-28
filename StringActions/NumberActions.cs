
namespace StringActions
{
    public class NumberActions
    {
        public static bool IsNumberCanBeDividedByAnotherNumber(int i_Number, int i_AnotherNumber)
        {
            bool result = (i_Number % i_AnotherNumber == 0);
            return result;
        }
    }
}
