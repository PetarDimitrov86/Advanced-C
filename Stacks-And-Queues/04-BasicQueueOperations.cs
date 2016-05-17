using System;
using System.Collections.Generic;
using System.Linq;
class BasicQueueOperations
{
    static void Main(string[] args)
    {
        int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = values[0];
        int s = values[1];
        int x = values[2];

        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Queue<int> originalQueue = new Queue<int>();
        for (int i = 0; i < n; i++)
            originalQueue.Enqueue(numbers[i]);
        for (int i = 0; i < s; i++)
            originalQueue.Dequeue();
        if (originalQueue.Count == 0)
        {
            Console.WriteLine("0");
            return;
        }
        if (originalQueue.Contains(x))
            Console.WriteLine("true");
        else
            Console.WriteLine(originalQueue.Min());
    }
}