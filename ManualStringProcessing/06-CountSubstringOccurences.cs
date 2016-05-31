using System;
class CountSubstringOccurences
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine().ToLower();
        string word = Console.ReadLine().ToLower();
        int counter = 0;
        int wordLength = word.Length;
        for (int i = 0; i < input.Length - wordLength + 1; i++)
        {
            if (input.Substring(i, wordLength) == word)
                counter++;
        }
        Console.WriteLine(counter);
    }
}