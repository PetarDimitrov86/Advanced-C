using System;
using System.Collections.Generic;
using System.Linq;
class SequenceWithQueue
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        Queue<long> originalQueue = new Queue<long>();
        Queue<long> smallQueue = new Queue<long>();
        smallQueue.Enqueue(n);
        originalQueue.Enqueue(n);
        for (int i = 0; i < 20; i++)
        {  
            originalQueue.Enqueue(smallQueue.Last() + 1);
            originalQueue.Enqueue(smallQueue.Last() * 2 + 1);
            originalQueue.Enqueue(smallQueue.Last() + 2);

            smallQueue.Enqueue(originalQueue.ElementAt(i + 1));
        }     
        for (int i = 0; i < 50; i++)
            Console.Write("{0} ", originalQueue.ElementAt(i));
        Console.WriteLine();
    }
}