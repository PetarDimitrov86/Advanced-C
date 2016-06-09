using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class LittleJohn
{
    static void Main(string[] args)
    {
        Dictionary<string, int> arrows = new Dictionary<string, int>();
        arrows[">----->"] = 0;
        arrows[">>----->"] = 0;
        arrows[">>>----->>"] = 0;

        for (int i = 0; i < 4; i++)
        {
            string input = Console.ReadLine();
            while (input.Contains(">----->"))
            {
                if (input.Contains(">>>----->>"))
                {
                    arrows[">>>----->>"]++;
                    input = input.Substring(input.IndexOf(">>>----->>") + 10);
                }
                else if (input.Contains(">>----->"))
                {
                    arrows[">>----->"]++;
                    input = input.Substring(input.IndexOf(">>----->") + 8);
                }
                else if (input.Contains(">----->"))
                {
                    arrows[">----->"]++;
                    input = input.Substring(input.IndexOf(">----->") + 7);
                }
            }
        }
        string result = string.Empty;
        foreach (var kvp in arrows)
            result += kvp.Value.ToString();
        int resultNum = int.Parse(result);
        string binary = Convert.ToString(resultNum, 2);

        string reversed = string.Empty;
        for (int i = binary.Length - 1; i >= 0; i--)
            reversed += binary[i];

        string finalBinary = binary + reversed;
        int finalAnswer = Convert.ToInt32(finalBinary, 2);
        Console.WriteLine(finalAnswer);
    }
}