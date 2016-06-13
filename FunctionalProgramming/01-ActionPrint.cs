using System;
using System.Linq;
class ActionPrint
{
    public static void Main(string[] args)
    {
        string[] text = Console.ReadLine().Split(' ').ToArray();
        Action<string> firstAction = Print;
        foreach (var item in text)
            firstAction(item);
    }
    public static void Print(string num)
    {
        Console.WriteLine(num);
    }
}