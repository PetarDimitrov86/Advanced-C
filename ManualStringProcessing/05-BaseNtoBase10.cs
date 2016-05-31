using System;
using System.Linq;
using System.Numerics;
class BaseNtoBase10
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();
        BigInteger baseNum = BigInteger.Parse(input[0]);
        string numberToConv = input[1];
        BigInteger result = BigInteger.Parse(numberToConv[0].ToString());
        for (int i = 0; i < numberToConv.Length - 1; i++)
        {
            BigInteger numToAdd = result * baseNum + BigInteger.Parse(numberToConv[i + 1].ToString());
            result = numToAdd;
        }
        Console.WriteLine(result);
    }
}