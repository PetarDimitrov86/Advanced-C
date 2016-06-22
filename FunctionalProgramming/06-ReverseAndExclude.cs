using System;
using System.Collections.Generic;
using System.Linq;
class ReverseAndExclude
{
    public static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
        int divisor = int.Parse(Console.ReadLine());
        Predicate<int> predic = x => x % divisor != 0;
        var result = ReverseExclude(numbers, predic);
        Console.WriteLine(string.Join(" ", result));
    }

    public static List<int> ReverseExclude(int[] nums, Predicate<int> predic)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (predic(nums[i]))
            {
                result.Add(nums[i]);
            }
        }
        return result;
    }
}