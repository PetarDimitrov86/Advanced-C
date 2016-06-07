using System;
using System.Collections.Generic;
using System.Linq;
class ActionPrint
{
    static void Main(string[] args)
    {
        string[] text = Console.ReadLine().Split(' ').ToArray();
        Action<string> print = message => Console.WriteLine(message);
        foreach (var item in text)
            print(item);
    }
}