using System;
class StringLength
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (input.Length < 21)
        {
            Console.Write(input);
            Console.WriteLine(new string('*', 20 - input.Length));
        }
        else
            Console.WriteLine(input.Substring(0, 20));
    }
}