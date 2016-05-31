using System;
using System.Text;
class MultiplyBigNumber
{
    static void Main(string[] args)
    {
        string InitialInput = Console.ReadLine();
        int timesToAdd = int.Parse(Console.ReadLine());
        StringBuilder result = new StringBuilder();
        if (timesToAdd == 0)
        {
            Console.WriteLine("0");
            return;
        }
        string input2 = InitialInput;
        string input1 = InitialInput;
        int remainder = 0;

        for (int i = 0; i < timesToAdd - 1; i++)
        {
            if (input1.Length < input2.Length)
                input1 = input1.PadLeft(input2.Length, '0');
            remainder = 0;
            for (int j = input2.Length - 1; j >= 0; j--)
            {
                int firstDigit = int.Parse(input1[j].ToString()) + remainder;
                int secondDigit = int.Parse(input2[j].ToString());

                result.Append((firstDigit + secondDigit) % 10);

                if (firstDigit + secondDigit >= 10)
                    remainder = 1;
                else
                    remainder = 0;
                if (j == 0 && remainder == 1)
                    result.Append(remainder);
            }
            input2 = string.Empty;
            for (int j = result.Length - 1; j >= 0; j--)
                input2 += result[j];
            result.Clear();
        }
        Console.WriteLine(input2.TrimStart('0'));
    }
}