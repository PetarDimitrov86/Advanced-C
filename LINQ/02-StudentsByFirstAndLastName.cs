using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
class StudentsByFirstAndLastName
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
        var result = names.Where(x => x.LastName.CompareTo(x.FirstName) == 1);
        foreach (var item in result)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }
}