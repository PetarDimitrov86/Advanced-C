﻿using System;
using System.Collections.Generic;
using System.Linq;
public class Students
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
public static class StudentsByAge
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
            tempStud.Age = int.Parse(data[2]);
            list.Add((tempStud));
            input = Console.ReadLine();
        }
        var result = list.Where(x => x.Age >= 18 && x.Age <= 24);
        foreach (var item in result)
            Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
    }
}