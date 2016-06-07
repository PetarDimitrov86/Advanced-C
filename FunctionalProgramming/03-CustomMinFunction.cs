using System;
using System.Linq;
class CustomMinFunction
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Func<int[], int> result = number => numbers.Min();
        Console.WriteLine(result(numbers));
    }
}