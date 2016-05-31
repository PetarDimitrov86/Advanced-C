using System;
using System.Text;
class UnicodeCharacters
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.Append("\\u");
            result.Append(string.Format("{0:x4}", (int)input[i]));
        }
        Console.WriteLine(result);
    }
}