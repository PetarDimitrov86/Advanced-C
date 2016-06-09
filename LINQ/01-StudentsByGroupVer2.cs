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
            nameList.Add(input);  
            input = Console.ReadLine();
        }
        var result = nameList.Select(x => x.Split()).Where(x => x.Contains("2")).OrderBy(x => x[0]);
        foreach (var item in result)
        {
            Console.WriteLine(item[0] + " " + item[1]);
        }
    }
}