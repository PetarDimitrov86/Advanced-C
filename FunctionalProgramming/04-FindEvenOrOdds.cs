using System;
using System.Linq;
class FindEvenOrOdds
{
    static void Main(string[] args)
    {
        int[] borders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        string type = Console.ReadLine();

        int lowerBorder = borders[0];
        int upperBorder = borders[1];
        Predicate<int> predic = n => n % 2 == 0;

        if (type == "odd")
            predic = n => n % 2 == 1;

        for (int i = lowerBorder; i <= upperBorder; i++)
        {
            if (predic(Math.Abs(i)))
                Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}