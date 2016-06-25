using System;
using System.Collections.Generic;
using System.Linq;
public static class InputReader
{
    private const string endCommand = "quit";

    public static void StartReadingCommands()
    {
        OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
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