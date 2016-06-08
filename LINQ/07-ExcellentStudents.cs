using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Marks { get; set; }
}
public static class ExcellentStudents
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Students> list = new List<Students>();
        while (input != "END")
        {
            string[] data = input.Split();
            Students tempStud = new Students();
            tempStud.FirstName = data[0];
            tempStud.LastName = data[1];
            tempStud.Marks = new List<int>();
            for (int i = 2; i < data.Length; i++)
                tempStud.Marks.Add(int.Parse(data[i]));
            list.Add((tempStud));
            input = Console.ReadLine();
        }
        var result = list.Where(x => x.Marks.Contains(6));
        foreach (var item in result)
            Console.WriteLine($"{item.FirstName} {item.LastName}");
    }
}