using System;
using System.Numerics;
using System.Text;
class SoftUniNumerals
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder text = new StringBuilder();
        StringBuilder result = new StringBuilder();
        text.Append(input);
        while (text.Length > 0)
        {
            string tempString = text.ToString();
            if (tempString.StartsWith("aa"))
            {
                text.Remove(0, 2);
                result.Append("0");
            }
            else if (tempString.StartsWith("aba"))
            {
                text.Remove(0, 3);
                result.Append("1");
            }
            else if (tempString.StartsWith("bcc"))
            {
                text.Remove(0, 3);
                result.Append("2");
            }
            else if (tempString.StartsWith("cc"))
            {
                text.Remove(0, 2);
                result.Append("3");
            }
            else if (tempString.StartsWith("cdc"))
            {
                text.Remove(0, 3);
                result.Append("4");
            }
        }
        string resultAsText = result.ToString();
        BigInteger resultNum = BigInteger.Parse(resultAsText[0].ToString());
        for (int i = 0; i < result.Length - 1; i++)
        {
            BigInteger tempNum = resultNum*5 + BigInteger.Parse(resultAsText[i + 1].ToString());
            resultNum = tempNum;
        }
        Console.WriteLine(resultNum);
    }
}