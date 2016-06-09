using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Person
{
    public string Name { get; set; }
    public int Group { get; set; }
}
class GroupByGroup
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Person> list = new List<Person>();
        while (input != "END")
        {
            string[] data = input.Split();
            Person students = new Person();
            students.Name = data[0] + " " + data[1];
            students.Group = int.Parse(data[2]);
            list.Add(students);
            input = Console.ReadLine();
        }
        var groups = list.OrderBy(y => y.Group).GroupBy(x => x.Group);
        foreach (var group in groups)
        {
            Console.Write("{0} - ", group.Key);
            List<string> newList = new List<string>();
            foreach (var item in group)
            {
                newList.Add(item.Name);
            }
            Console.Write(string.Join(", ", newList));           
            Console.WriteLine();
        }
    }
}