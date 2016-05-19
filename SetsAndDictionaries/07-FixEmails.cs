using System;
using System.Collections.Generic;
class FixEmails
{
    static void Main(string[] args)
    {
    string name = Console.ReadLine();
    string email = Console.ReadLine();
    Dictionary<string, string> contacts = new Dictionary<string, string>();
        Dictionary<string, string> result = new Dictionary<string, string>();
    while (name != "stop")
        {
            if (!contacts.ContainsKey(name))
                contacts[name] = email;
            name = Console.ReadLine();
            if (name == "stop")
                break;
            email = Console.ReadLine();
        }

        foreach (var kvp in contacts)
        {
            string emailValue = kvp.Value;
            string[] emailarr = emailValue.Split('.');
            string host = emailarr[emailarr.Length - 1];
            if (host != "uk" && host != "us")
                result.Add(kvp.Key, kvp.Value);
        }
        foreach (var kvp in result)
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
    }
}