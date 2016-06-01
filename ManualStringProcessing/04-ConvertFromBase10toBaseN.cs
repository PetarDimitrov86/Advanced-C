using System;
using System.Linq;
using System.Numerics;
class ConvertFromBase10toBaseN
{
    static void Main(string[] args)
    {
        BigInteger[] nums = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
        BigInteger baseNum = nums[0];
        BigInteger number = nums[1];
        BigInteger result = 0;
        BigInteger counter = 1;
        while (number > 0)
        {
            result += (number % baseNum) * counter;
            number /= baseNum;
            counter *= 10;
        }
        Console.WriteLine(result);
    }
}