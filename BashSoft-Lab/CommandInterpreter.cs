using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class CommandInterpreter
{
    public static void IntepredCommand(string input)
    {
        string[] data = input.Split(' ');
        string command = data[0];
        switch (command)
        {
            case "open":
                TryOpenFile(input, data);
                break;
            case "mkdir":
                TryCreateDirectory(input, data);
                break;
            case "ls":
                TryTraverseFolders(input, data);
                break;
            case "cmp":
                TryComparеFiles(input, data);
                break;
            case "cdRel":
                TryChangePathRelatively(input, data);
                break;
            case "cdAbs":
                TryChangePathAbsolute(input, data);
                break;
            case "readDb":
                TryReadDatabaseFromFile(input, data);
                break;
            case "help":
                TryGetHelp(input, data);
                break;
            case "filter":
                break;
            case "order":
                break;
            case "decOrder":
                break;
            case "download":
                break;
            case "downloadAsynch":
                break;
            default:
                ExceptionMessages.DisplayInvalidCommandMessage(input);
                break;
        }

    }
    public static void TryOpenFile(string input, string[] data)
    {
        string fileName = data[1];
        Process.Start(SessionData.currentPath + "\\" + fileName);
    }
    public static void TryCreateDirectory(string input, string[] data)
    {
        string folderName = data[1];
        IOManager.CreateDirectoryInCurrentFolder(folderName);
    }
    public static void TryTraverseFolders(string input, string[] data)
    {
        if (data.Length == 1)
            IOManager.TraverseDirectory(0);
        else if (data.Length == 2)
        {
            int depth;
            bool hasParsed = int.TryParse(data[1], out depth);
            if (hasParsed)
            {
                IOManager.TraverseDirectory(depth);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
            }
        }
    }
    public static void TryComparеFiles(string input, string[] data)
    {
        string firstPath = data[1];
        string secondPath = data[2];
        Tester.CompareContent(firstPath, secondPath);
    }
    public static void TryChangePathRelatively(string input, string[] data)
    {
        string relPath = data[1];
        IOManager.ChangeCurrentDirectoryRelative(relPath);
    }
    public static void TryChangePathAbsolute(string input, string[] data)
    {
        string absolutePath = data[1];
        IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
    }
    public static void TryReadDatabaseFromFile(string input, string[] data)
    {
        string fileName = data[1];
        Data.InitializeData(fileName);
    }
}
