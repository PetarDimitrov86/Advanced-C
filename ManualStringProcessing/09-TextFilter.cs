using System;
using System.Linq;
class TextFilter
{
    static void Main(string[] args)
    {
        string[] badWords = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries ).ToArray();
        string input = Console.ReadLine();
        string result = String.Empty;
        foreach (var item in badWords)
        {
            result = input.Replace(item, new string('*', item.Length));
            input = result;
        }
        Console.WriteLine(result);
    }
}