using System;
using System.Collections.Generic;
class TruckTour
{
    static void Main(string[] args)
    {
        Queue<string> petrolPumps = new Queue<string>();
        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            input += " " + i;
            petrolPumps.Enqueue(input);
        }
        bool journeyComplete = false;
        string starterPump = string.Empty;

        while (true)
        {
            string currentPump = petrolPumps.Peek();
            string[] info = petrolPumps.Dequeue().Split(' ');
            petrolPumps.Enqueue(currentPump);

            starterPump = currentPump;
            int tank = int.Parse(info[0]);
            int distanceToNextStation = int.Parse(info[1]);
            while (tank >= distanceToNextStation)
            {
                currentPump = petrolPumps.Dequeue();
                string[] info2 = currentPump.Split(' ');
                petrolPumps.Enqueue(currentPump);
                tank -= int.Parse(info2[1]);
                if (currentPump == starterPump)
                {
                    journeyComplete = true;
                    break;
                }
                tank += int.Parse(info2[0]);
            }
            if (journeyComplete)
            {
                string[] pump = starterPump.Split(' ');
                Console.WriteLine(pump[2]);
                break;
            }
        }
    }
}