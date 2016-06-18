using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Monopoly
{
    public static int playerCash = 50;
    public static int hotelsOwned = 0;
    public static int totalTurns = 0;
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];        


        char[,] matrix = new char[rows, cols];
        
        for (int row = 0; row < rows; row++)
        {
            char[] cells = Console.ReadLine().ToArray();
            for (int col = 0; col < cols; col++)
                matrix[row, col] = cells[col];
        }
        for (int row = 0; row < rows; row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < cols; col++)
                {                
                    PerformAction(matrix, row, col);
                    totalTurns++;
                    playerCash += hotelsOwned * 10;
                }
            }
            else if (row % 2 == 1)
            {
                for (int col = cols - 1; col >= 0; col--)
                {                   
                    PerformAction(matrix, row, col);
                    totalTurns++;
                    playerCash += hotelsOwned * 10;
                }
            }
        }
        Console.WriteLine("Turns {0}", totalTurns);
        Console.WriteLine("Money {0}", playerCash);
    }
    private static void PerformAction(char[,] matrix, int row, int col)
    {
        switch (matrix[row, col])
        {
            case 'H':
                int oldCash = playerCash;
                playerCash = 0;
                hotelsOwned++;
                Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", oldCash, hotelsOwned);
                break;
            case 'J':
                Console.WriteLine("Gone to jail at turn {0}.", totalTurns);
                totalTurns += 2;
                playerCash += 2*hotelsOwned*10;
                break;
            case 'S':
                int spentCash = 0;
                if (playerCash >= (row + 1) * (col + 1))
                {
                    playerCash -= (row + 1)*(col + 1);
                    spentCash = (row + 1)*(col + 1);
                }
                else
                {
                    spentCash = playerCash;
                    playerCash = 0;
                }
                Console.WriteLine("Spent {0} money at the shop.", spentCash);
                break;
            case 'F':
                break;
        }
    }
}