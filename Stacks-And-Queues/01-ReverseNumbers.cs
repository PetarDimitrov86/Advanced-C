using System;
using System.Collections.Generic;
using System.Linq;
class ReverseNumbers
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Stack<int> originalStack = new Stack<int>(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(originalStack.Peek());
            originalStack.Pop();
            if (i != arr.Length - 1)
                Console.Write(" ");
            else
                Console.WriteLine();
        }
    }
}