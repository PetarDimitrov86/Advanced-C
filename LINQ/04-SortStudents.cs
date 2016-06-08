using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public static class SortStudents
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Students> names = new List<Students>();
        while (input != "END")
        {
            string[] command = input.Split();
            Students tempStud = new Students();
            tempStud.FirstName = command[0];
            tempStud.LastName = command[1];
            names.Add(tempStud);
            input = Console.ReadLine();
        }
        var result = names.OrderBy(x => x.LastName).ThenByDescending(x => x.FirstName);
        foreach (var item in result)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }
}