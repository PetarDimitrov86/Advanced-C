using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FacultyNum { get; set; }
    public List<int> Marks { get; set; }
}
public static class StudentsEnrollde20142015
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Students> list = new List<Students>();
        while (input != "END")
        {
            string[] data = input.Split();
            Students tempStud = new Students();
            tempStud.FacultyNum = data[0];
            string year = data[0].Substring(data[0].Length - 2, 2);
            if (year == "14" || year == "15")
            {
                tempStud.Marks = new List<int>();
                for (int i = 1; i < data.Length; i++)
                    tempStud.Marks.Add(int.Parse(data[i]));
                list.Add((tempStud));
            }
            input = Console.ReadLine();
        }
        foreach (var item in list)
        {
            Console.WriteLine(string.Join(" ", item.Marks));
        }
    }
}