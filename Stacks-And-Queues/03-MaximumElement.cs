using System;
using System.Collections.Generic;
using System.Linq;
class MaximumElement
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> originalStack = new Stack<int>();
        Stack<int> maxNumbers = new Stack<int>();
        int maxNumber = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            if (input[0] == '1')
            {
                int[] command = input.Split(' ').Select(int.Parse).ToArray();
                int currentNumber = command[1];
                originalStack.Push(currentNumber);
                if (currentNumber >= maxNumber)
                {
                    maxNumber = currentNumber;
                    maxNumbers.Push(currentNumber);
                }
            }
            else if (input[0] == '2')
            {
                int lastNumber = originalStack.Pop();
                int maxNumInMaxStack = maxNumbers.Peek();
                if (lastNumber == maxNumInMaxStack)
                {
                    maxNumbers.Pop();
                    if (maxNumbers.Count > 0)
                    {
                        maxNumber = maxNumbers.Peek();
                    }
                    else
                        maxNumber = int.MinValue;
                }   
            }
            else if (input[0] == '3')
            {
                int largetsNum = maxNumbers.Peek();
                Console.WriteLine(largetsNum);
            }
        }
    }
}