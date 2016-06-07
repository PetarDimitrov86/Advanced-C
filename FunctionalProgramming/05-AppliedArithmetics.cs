using System;
using System.Collections.Generic;
using System.Linq;
class AppliedArithmetics
{
    public static class Functions
    {
        public static void Print(List<int> collection, Action<List<int>> act)
        {
            act(collection);
        }
        public static List<int> ApplyFunc(List<int> collection, Func<int, int> func)
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                int modifiedItem = func(item);
                result.Add(modifiedItem);
                //result.Add(func(item));
            }
            return result;
        }
    }
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        string input = Console.ReadLine();
        while (input != "end")
        {
            switch (input)
            {
                case "add":
                    numbers = Functions.ApplyFunc(numbers, x => x + 1);
                    break;
                case "subtract":
                    numbers = Functions.ApplyFunc(numbers, x => x - 1);
                    break;
                case "multiply":
                    numbers = Functions.ApplyFunc(numbers, x => x * 2);
                    break;
                case "print":
                    Functions.Print(numbers, x => Console.WriteLine(string.Join(" ", numbers)));
                    break;
            }
           input = Console.ReadLine();
        }

    }
}