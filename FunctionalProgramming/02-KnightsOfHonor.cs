using System;
using System.Linq;
class KnightsOfHonor
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Action<string> print = name => Console.WriteLine("Sir " + name);
        foreach (var item in input)
            print(item);
    }
}