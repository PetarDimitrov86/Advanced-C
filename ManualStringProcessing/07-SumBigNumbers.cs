using System;
using System.Text;
class SumBigNumbers
{
    static void Main(string[] args)
    {
        string InitialInput1 = Console.ReadLine();
        string InitialInput2 = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        string input1 = string.Empty;
        string input2 = string.Empty;
        int remainder = 0;
        if (InitialInput1.Length <= InitialInput2.Length)
        {
            input1 = InitialInput1.PadLeft(InitialInput2.Length, '0');
            input2 = InitialInput2;
        }
        else if (InitialInput2.Length <= InitialInput1.Length)
        {
            input2 = InitialInput2.PadLeft(InitialInput1.Length, '0');
            input1 = InitialInput1;
        }
        for (int i = input1.Length - 1; i >= 0; i--)
        {
            int firstDigit = int.Parse(input1[i].ToString()) + remainder;
            int secondDigit = int.Parse(input2[i].ToString());
            result.Append((firstDigit + secondDigit) % 10);
            if (firstDigit + secondDigit >= 10)
                remainder = 1;
            else
                remainder = 0;
            if (i == 0 && remainder == 1)
                result.Append(remainder);
        }
        string finalAnswer = string.Empty;

        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (result[i] != '0')
            {
                finalAnswer += result[i];
                break;
            }
            else
                result.Remove(i, 1);
        }
        for (int i = result.Length - 2; i >= 0; i--)
            finalAnswer += result[i];
        Console.WriteLine(finalAnswer);
    }
}