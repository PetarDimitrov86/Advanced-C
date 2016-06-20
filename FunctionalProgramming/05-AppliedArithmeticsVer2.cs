using System;
using System.Linq;
class AppliedArithmetics
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        string input = Console.ReadLine();

        while (input!="end")
        {
            if (input == "add" || input == "multiply" || input == "subtract")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = ApplyOperation(numbers[i], n => n, input);
                }
            }
            else if (input == "print")
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            input = Console.ReadLine();
        }
    }

    public static int ApplyOperation(int num, Func<int, int> func, string input)
    {
        int result = 0;
        switch (input)
        {
            case "add":
                func = n => n + 1;
                result = func(num);
                break;
            case "multiply":
                func = n => n * 2;
                result = func(num);
                break;
            case "subtract":
                func = n => n - 1;
                result = func(num);
                break;
        }
        return result;
    }
}
