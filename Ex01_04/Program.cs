using System;
using StringActions;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string str , msg;
            string isPalindrom, isNumberDividedBy3;
            int numberOfUpperCasesInStr = 0, number;
            eCharType type = eCharType.Unknown;
            str = GetStrAndCheckValidation(ref type);
            isPalindrom = AnswerForIsStringPalindrom(str); 
            //decided to saperate the cases of letters string or numbers string because they are differ in data that we need to check.
            //also this way makes the code WYSWYG
            if(type == eCharType.Letter)
            {
                numberOfUpperCasesInStr = StringActions.LetterActions.CountUpperCaseInStr(str);
                msg = OrganizeDataOfLettersStr(isPalindrom, numberOfUpperCasesInStr);
            }
            else
            {
                number = int.Parse(str);
                isNumberDividedBy3 = AnswerForIsNumberCanBeDividedByAnotherNumber(number, 3);
                msg = OrganizeDataOfNumberStr(isPalindrom, isNumberDividedBy3);
            }
            Console.WriteLine(msg);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
        public static string GetStrAndCheckValidation(ref eCharType io_Type)
        {
            string l_str;
            bool l_condition = false;
            Console.WriteLine("Please enter an only digits or only letters string in lenght 6");
            do
            {
                l_str = Console.ReadLine();
                l_condition = IsStrValid(l_str, ref io_Type);
                if (l_condition == false)
                {
                    Console.WriteLine("invalid input!\nPlease enter again");
                }
            } while (l_condition == false);
            return l_str;
        }
        public static bool IsStrValid(string i_Str, ref eCharType io_Type)
        {
            int length = i_Str.Length;
            if(length != 6)
            {
                return false;
            }
            if (char.IsLetter(i_Str[0]) == true)
            {
                for (int i = 1; i < length; i++)
                {
                    if (char.IsLetter(i_Str[i]) == false)
                    {
                        return false;
                    }
                }
                io_Type = eCharType.Letter;
            }
            else if (char.IsDigit(i_Str[0]) == true)
            {
                for (int j = 1; j < length; j++)
                {
                    if (char.IsDigit(i_Str[j]) == false)
                    {
                        return false;
                    }
                }
                io_Type = eCharType.Digit;
            }
            else
            {
                return false;
            }
            return true;
        }
        public static string OrganizeDataOfNumberStr(string i_IsPalindrom, string i_IsNumberDividedBy3)
        {
            string msg = string.Format(
@"This is a numbers string.
This number {0} a palindrom.
This number {1} divided by 3.
                ", i_IsPalindrom, i_IsNumberDividedBy3);
            return msg;
        }
        public static string OrganizeDataOfLettersStr(string i_IsPalindrom, int i_NumberOfUpperCasesInStr)
        {
            string msg = string.Format(
@"This is a letters string.
This string {0} a palindrom.
This string has {1} upper case letter(s).
                ", i_IsPalindrom, i_NumberOfUpperCasesInStr);
            return msg;
        }
        public static string ChangeBoolToAnswer(bool i_Answer)
        {
            if (i_Answer == true)
            {
                return "is";
            }
            else
            {
                return "is not";
            }
        }
        public static string AnswerForIsNumberCanBeDividedByAnotherNumber(int i_Number, int i_AnotherNumer)
        {
            bool answer = StringActions.NumberActions.IsNumberCanBeDividedByAnotherNumber(i_Number, i_AnotherNumer);
            string answerStr = ChangeBoolToAnswer(answer);
            return answerStr;
        }
        public static string AnswerForIsStringPalindrom(string i_Str)
        {
            bool answer = StringActions.GeneralActions.IsStringPalindrom(i_Str);
            string answerStr = ChangeBoolToAnswer(answer);
            return answerStr;
        }
        public enum eCharType
        {
            Letter,
            Digit,
            Unknown
        }
    }
}
