using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class InputReader
{
    private const string endCommand = "quit";

    public static void StartReadingCommands()
    {
        string input = Console.ReadLine();
        while (input != endCommand)
        {
            CommandInterpreter.IntepredCommand(input);
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            input = Console.ReadLine();
            input = input.Trim();
        }
    }
}