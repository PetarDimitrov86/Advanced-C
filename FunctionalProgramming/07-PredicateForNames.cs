using System;
using System.Linq;
class PredicateForNames
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(' ').ToArray();
        Predicate<string> predic = x => x.Length <= length;
        foreach (var name in names)
        {
            if (predic(name))
            {
                Console.WriteLine(name);
            }
        }
    }
}