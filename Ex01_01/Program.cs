using System;
using System.Text;
using StringActions;

namespace Ex01_0X
{
    public class Program
    {
        public static void Main()
        {
            string numberStr;
            int number;
            int zeroCounter = 0, oneCounter = 0;
            int howManyNubersDividedByFour = 0, HowManyNumbersArePalindrom = 0;
            int howManyNubersAreDescendingSeries = 0;
            int amountOfNumbers = 3;
            Console.WriteLine("Please enter 3 numbers in binary representation");
            for (int i = 0; i < amountOfNumbers; i++)
            {
                numberStr = GetNumberFromUserAndCheckValidation(ref zeroCounter, ref oneCounter);
                number = int.Parse(numberStr);
                number = BinaryToDecimal(number);
                numberStr = number.ToString(); // create a string without unnessesary zeroes
                if (StringActions.NumberActions.IsNumberCanBeDividedByAnotherNumber(number, 4) == true)
                {
                    howManyNubersDividedByFour++;
                }
                if (IsNumberDescendingSeries(number) == true)
                {
                    howManyNubersAreDescendingSeries++;
                }
                if (StringActions.GeneralActions.IsStringPalindrom(numberStr) == true)
                {
                    HowManyNumbersArePalindrom++;
                }
            }
            PrintStats(howManyNubersDividedByFour, howManyNubersAreDescendingSeries, HowManyNumbersArePalindrom, zeroCounter, oneCounter, amountOfNumbers);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
        public static void PrintStats(int i_HowManyNubersDividedByFour, int i_HowManyNubersAreDescendingSeries, int i_HowManyNumbersArePalindrom, int i_ZeroCounter, int i_OneCounter, int i_AmountOfNumbers)
        {
            string msg;
            float avgNumberOfZeroes = i_ZeroCounter / (float)i_AmountOfNumbers;
            float avgNumberOfOnes = i_OneCounter / (float)i_AmountOfNumbers;
            msg = string.Format(
                @"Statistics:
The average number of zeroes is {0}.
The average number of ones is {1}.
{2} numbers are divided by four.
{3} numbers are descending series.
{4} numbers are palindroms."
                , avgNumberOfZeroes, avgNumberOfOnes, i_HowManyNubersDividedByFour,
                i_HowManyNubersAreDescendingSeries, i_HowManyNumbersArePalindrom
                );
            Console.WriteLine(msg);
        }
        public static int BinaryToDecimal(int i_BinaryNumber)
        {
            int numberConvertedToDecimal = 0;
            int currentBit;
            int position = 0;
            while (i_BinaryNumber != 0)
            {
                currentBit = ExtractLastDigitFromNumberAndRemoveIt(ref i_BinaryNumber);
                numberConvertedToDecimal += currentBit * (int)System.Math.Pow(2, position);
                position++;
            }
            return numberConvertedToDecimal;
        }
        public static string GetNumberFromUserAndCheckValidation(ref int io_ZeroCounter, ref int io_OneCounter)
        {
            bool condition;
            string numberStr;
            do
            {
                numberStr = Console.ReadLine();
                if (numberStr.Length == 8)
                {
                    condition = CountOnesAndZeroesInNumberAndCheckIfBinary(numberStr, ref io_ZeroCounter, ref io_OneCounter);
                }
                else
                {
                    Console.WriteLine("invalid input!\nEnter a number again please");
                    condition = false;
                }

            } while (condition == false);
            return numberStr;
        }
        public static int GetNumberFromUser()
        {
            string numberStr = Console.ReadLine();
            int number = int.Parse(numberStr);
            return number;
        }
        public static bool CountOnesAndZeroesInNumberAndCheckIfBinary(string i_NumberStr, ref int io_ZeroCounter, ref int io_OneCounter)
        {
            char digit;
            int zeroCounter = 0, oneCounter = 0;
            for (int i = 0; i < 8; i++)
            {
                digit = i_NumberStr[i];
                if (digit == '0')
                {
                    zeroCounter++;
                }
                else if (digit == '1')
                {
                    oneCounter++;
                }
                else
                {
                    Console.WriteLine("invalid input!\nEnter a number again please");
                    return false;
                }
            }
            io_ZeroCounter += zeroCounter;
            io_OneCounter += oneCounter;
            return true;
        }
        public static int ExtractLastDigitFromNumberAndRemoveIt(ref int io_Number)
        {
            int digitToExtract = io_Number % 10;
            io_Number = io_Number / 10;
            return digitToExtract;
        }
        public static bool IsNumberDescendingSeries(int i_Number)
        {
            int lastDigit, beforeLastDigit;
            lastDigit = ExtractLastDigitFromNumberAndRemoveIt(ref i_Number);
            while (i_Number != 0)
            {
                beforeLastDigit = ExtractLastDigitFromNumberAndRemoveIt(ref i_Number);
                if (beforeLastDigit <= lastDigit)
                {
                    return false;
                }
                lastDigit = beforeLastDigit;
            }
            return true;
        }
    }
}
