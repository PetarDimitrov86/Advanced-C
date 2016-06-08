using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FacultyNum { get; set; }
    public List<int> Marks { get; set; }
}
public static class StudentsEnrolledVer2
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
            tempStud.Marks = new List<int>();
            for (int i = 1; i < data.Length; i++)
                tempStud.Marks.Add(int.Parse(data[i]));
            list.Add((tempStud));           
            input = Console.ReadLine();
        }
        var result =
            list.Where(x =>
                    x.FacultyNum[x.FacultyNum.Length - 2] == '1' &&
                    (x.FacultyNum[x.FacultyNum.Length - 1] == '4' || 
                    x.FacultyNum[x.FacultyNum.Length - 1] == '5'));
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(" ", item.Marks));
        }
    }
}