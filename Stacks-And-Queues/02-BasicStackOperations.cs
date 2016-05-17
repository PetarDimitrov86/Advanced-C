using System;
using System.Collections.Generic;
using System.Linq;
class BasicStackOperations
{
    static void Main(string[] args)
    {
        int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = values[0];
        int s = values[1];
        int x = values[2];

        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Stack<int> originalStack = new Stack<int>();
        for (int i = 0; i < n; i++)
            originalStack.Push(numbers[i]);
        for (int i = 0; i < s; i++)
            originalStack.Pop();
        if (originalStack.Count == 0)
        {
            Console.WriteLine("0");
            return;
        }
        if (originalStack.Contains(x))
            Console.WriteLine("true");
        else
            Console.WriteLine(originalStack.Min());
    }
}