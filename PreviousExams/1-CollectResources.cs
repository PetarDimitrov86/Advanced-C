using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CollectResources
{
    static void Main(string[] args)
    {
        string[] resourceField = Console.ReadLine().Split();
        int numberOfPaths = int.Parse(Console.ReadLine());
        Dictionary<string, int> resources = new Dictionary<string, int>();
        resources["stone"] = 0;
        resources["gold"] = 0;
        resources["wood"] = 0;
        resources["food"] = 0;
        int maxPossibleCollected = int.MinValue;
        for (int i = 0; i < numberOfPaths; i++)
        {
            int[] startStep = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startIndex = startStep[0];
            int stepIndex = startStep[1];
            string[] tempResources = new string[resourceField.Length];
            resourceField.CopyTo(tempResources, 0);
            while (tempResources[startIndex] != "empty")
            {
                string currentResource = tempResources[startIndex];
                string resourceType = string.Empty;
                int resourceQuantity = 0;
                try
                {
                    string[] resourceInfo = currentResource.Split('_');
                    resourceType = resourceInfo[0];
                    resourceQuantity = int.Parse(resourceInfo[1]);
                }
                catch (Exception)
                {
                    resourceType = currentResource;
                    resourceQuantity = 1;
                }
                if (resources.ContainsKey(resourceType))
                {
                    resources[resourceType] += resourceQuantity;
                    tempResources[startIndex] = "empty";
                }              
                startIndex = (startIndex + stepIndex)%resourceField.Length;
            }
            int currentlyCollected = resources.Values.Sum();
            if (currentlyCollected > maxPossibleCollected)
            {
                maxPossibleCollected = currentlyCollected;
            }
            resources["stone"] = 0;
            resources["gold"] = 0;
            resources["wood"] = 0;
            resources["food"] = 0;
        }
        Console.WriteLine(maxPossibleCollected);
    }
}