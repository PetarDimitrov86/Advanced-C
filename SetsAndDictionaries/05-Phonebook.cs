using System;
using System.Collections.Generic;
class Phonebook
{
    static void Main(string[] args)
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string input = Console.ReadLine();
        while (input != "search")
        {
            string[] command = input.Split('-');
            string name = command[0];
            string number = command[1];
            if (!phonebook.ContainsKey(name))
                phonebook[name] = null;
            phonebook[name] = number;
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "stop")
        {
            if (phonebook.ContainsKey(input))
                Console.WriteLine("{0} -> {1}", input, phonebook[input]);
            else
                Console.WriteLine("Contact {0} does not exist.", input);
            input = Console.ReadLine();
        }
    }
}