using System;
class MelrahShake
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();
        while (text.Contains(pattern) && text.IndexOf(pattern) != text.LastIndexOf(pattern) && pattern.Length > 0)
        {
            int leftOne = text.IndexOf(pattern);
            text = text.Remove(leftOne, pattern.Length);
            int rightOne = text.LastIndexOf(pattern);
            text = text.Remove(rightOne, pattern.Length);
            pattern = pattern.Remove(pattern.Length/2, 1);
            Console.WriteLine("Shaked it.");
        }
        Console.WriteLine("No shake.");
        Console.WriteLine(text);
    }
}