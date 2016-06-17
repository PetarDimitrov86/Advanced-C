using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BunkerBuster
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            int[] cells = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < cols; col++)
                matrix[row, col] = cells[col];
        }

        string bomb = Console.ReadLine();
        while (bomb != "cease fire!")
        {
            string[] bombAttributes = bomb.Split();
            int bombRow = int.Parse(bombAttributes[0]);
            int bombCol = int.Parse(bombAttributes[1]);
            char powerChar = char.Parse(bombAttributes[2]);
            int power = (int) powerChar;
            for (int row = bombRow - 1; row <= bombRow + 1; row++)
            {
                for (int col = bombCol - 1; col <= bombCol + 1; col++)
                {
                    if (row == bombRow && col == bombCol)
                    {
                        matrix[row, col] -= power;
                    }
                    else if (row >= 0 && col >= 0 && row < rows  && col < cols)
                    {
                        matrix[row, col] -= (int)Math.Ceiling(power / 2.0);
                    }
                }
            }
            bomb = Console.ReadLine();
        }
        int bunkersDestroyed = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col] <= 0)
                {
                    bunkersDestroyed++;
                }
            }
        }
        Console.WriteLine("Destroyed bunkers: {0}", bunkersDestroyed);
        Console.WriteLine("Damage done: {0:f1} %", (double)bunkersDestroyed * 100/ (rows * cols));
    }
}