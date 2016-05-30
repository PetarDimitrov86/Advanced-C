using System;
using System.Collections.Generic;
class BalancedParentheses
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<char> symbols = new Stack<char>();
        if (input.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                symbols.Push(input[i]);
            else
            {
                char currentSymbol = input[i];
                if ((currentSymbol == ')' && symbols.Peek() == '(') || (currentSymbol == ']' && symbols.Peek() == '[') || (currentSymbol == '}' && symbols.Peek() == '{'))
                    symbols.Pop();
            }
        }
        if (symbols.Count == 0)
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
}