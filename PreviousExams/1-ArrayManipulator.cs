using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ArrayManipulator
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] command = input.Split();
            var result = new List<int>();
            switch (command[0])
            {
                case "exchange":
                    int splitIndex = int.Parse(command[1]);
                    if (splitIndex < 0 || splitIndex > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    result.AddRange(numbers.Skip(splitIndex + 1).Take(numbers.Count - splitIndex));
                    result.AddRange(numbers.Take(splitIndex + 1));
                    numbers.Clear();
                    numbers.AddRange(result);
                    break;
                case "max":
                    if (command[1] == "even")
                    {
                        try
                        {
                            Console.WriteLine(numbers.LastIndexOf(numbers.Where(x => x % 2 == 0).Max()));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine(numbers.LastIndexOf(numbers.Where(x => x % 2 == 1).Max()));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No matches");
                        }
                    }            
                    break;
                case "min":
                    if (command[1] == "even")
                    {
                        try
                        {
                            Console.WriteLine(numbers.LastIndexOf(numbers.Where(x => x % 2 == 0).Min()));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine(numbers.LastIndexOf(numbers.Where(x => x % 2 == 1).Min()));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    break;
                case "first":
                    int count = int.Parse(command[1]);
                    string type = command[2];
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }
                    if (type == "even")
                    {
                        Console.WriteLine("[{0}]", string.Join(", ", numbers.Where(x => x % 2 ==0).Take(count)));
                    }
                    else
                    {
                        Console.WriteLine("[{0}]", string.Join(", ", numbers.Where(x => x % 2 == 1).Take(count)));
                    }
                    break;
                case "last":
                    count = int.Parse(command[1]);
                    type = command[2];
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }
                    if (type == "even")
                    {
                        var resultTemp = numbers.Where(x => x%2 == 0);
                        Console.WriteLine("[{0}]", string.Join(", ", resultTemp.Skip(resultTemp.Count() - count).Take(count)));
                    }
                    else
                    {
                        var resultTemp = numbers.Where(x => x % 2 == 1);
                        Console.WriteLine("[{0}]", string.Join(", ", resultTemp.Skip(resultTemp.Count() - count).Take(count)));
                    }
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }
}