using System;
using System.Collections.Generic;
using System.Linq;
class ArrangeNumbers
{
    static void Main(string[] args)
    {
        string[] numsString = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, Dictionary<string, int>> givenNumbers = new Dictionary<string, Dictionary<string, int>>();
        for (int i = 0; i < numsString.Length; i++)
        {
            string numAsText = GetStringResult(numsString[i]);
            if (!givenNumbers.ContainsKey(numAsText))
            {
                givenNumbers.Add(numAsText, new Dictionary<string, int>());
            }
            if (!givenNumbers[numAsText].ContainsKey(numsString[i]))
            {
                givenNumbers[numAsText].Add(numsString[i], 0);
            }
            givenNumbers[numAsText][numsString[i]]++;
        }
        var result = givenNumbers.OrderBy(x => x.Key);
        string answer = string.Empty;
        foreach (var outerPair in result)
        {
            foreach (var innerPair in outerPair.Value)
            {
                for (int i = 0; i < innerPair.Value; i++)
                {
                    answer += $"{innerPair.Key}, ";
                }
            }
        }
        answer = answer.Substring(0, answer.Length - 2);
        Console.WriteLine(answer);
    }

    public static string GetStringResult(string number)
    {
        string result = string.Empty;
        Dictionary<string, string> simpleNumsDict = new Dictionary<string, string>();
        simpleNumsDict.Add("0", "zero");
        simpleNumsDict.Add("1", "one");
        simpleNumsDict.Add("2", "two");
        simpleNumsDict.Add("3", "three");
        simpleNumsDict.Add("4", "four");
        simpleNumsDict.Add("5", "five");
        simpleNumsDict.Add("6", "six");
        simpleNumsDict.Add("7", "seven");
        simpleNumsDict.Add("8", "eight");
        simpleNumsDict.Add("9", "nine");
        for (int i = 0; i < number.Length; i++)
        {
            result += simpleNumsDict[number[i].ToString()] + "-";
        }
        result = result.Substring(0, result.Length - 1);
        return result;
    }
}