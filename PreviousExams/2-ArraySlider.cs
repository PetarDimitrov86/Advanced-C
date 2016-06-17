using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class ArraySlider
{
    static void Main(string[] args)
    {
        BigInteger[] originalArray =
        Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(BigInteger.Parse).ToArray();
        string input = Console.ReadLine();
        int currentIndex = 0;
        while (input != "stop")
        {
            string[] command = input.Split();
            int offset = int.Parse(command[0]) % originalArray.Length;
            char operation = char.Parse(command[1]);
            BigInteger operrand = BigInteger.Parse(command[2]);
            if (offset < 0)
            {
                offset += originalArray.Length;
            }
            currentIndex = (currentIndex + offset) % originalArray.Length;
            originalArray[currentIndex] = GetNewValue(originalArray[currentIndex], operation, operrand);
            if (originalArray[currentIndex] < 0)
                originalArray[currentIndex] = 0;
            input = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", originalArray));
    }
    private static BigInteger GetNewValue(BigInteger original, char operation, BigInteger operrand)
    {
        switch (operation)
        {
            case '&': return original & operrand;
            case '|': return original | operrand;
            case '^': return original ^ operrand;
            case '+': return original + operrand;
            case '-': return original - operrand;
            case '*': return original * operrand;
            case '/': return original / operrand;
            default:
                return 0;
        }
    }
}