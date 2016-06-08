using System;
using System.Collections.Generic;
using System.Linq;
public static class StudentsByGroup
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<string> nameList = new List<string>();
        while (input != "END")
        {
            string[] command = input.Split();
            string firstName = command[0];
            string lastName = command[1];
            int group = int.Parse(command[2]);

            if (group == 2)
                nameList.Add(firstName + " " + lastName);   
            input = Console.ReadLine();
        }
        var result = nameList.OrderBy(x => x);
            foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}