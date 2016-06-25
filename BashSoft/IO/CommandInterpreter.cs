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
            case "show":
                TryShowWantedData(input, data);
                break;
            case "filter":
                TryFilterAndTake(input, data);
                break;
            case "order":
                TryOrderAndTake(input, data);
                break;
            //case "decOrder":   //never used? we have a seperate command "decreasing" in the order command
            //    break;
            case "download":
                TryDownloadRequestedFile(input, data);
                break;
            case "downloadAsynch":
                TryDownloadRequestedFileAsync(input, data);
                break;
            default:
                DisplayInvalidCommandMessage(input);
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
    private static void TryGetHelp(string input, string[] data)
    {
        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
        OutputWriter.WriteEmptyLine();
    }
    private static void TryShowWantedData(string input, string[] data)
    {
        if (data.Length == 2)
        {
            string courseName = data[1];
            Data.GetAllStudentsFromCourse(courseName);
        }
        else if (data.Length == 3)
        {
            string courseName = data[1];
            string userName = data[2];
            Data.GetStudentScoresFromCourse(courseName, userName);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }
    public static void DisplayInvalidCommandMessage(string input)
    {
        OutputWriter.DisplayException($"The command '{input}' is invalid");
    }

    private static void TryFilterAndTake(string input, string[] data)
    {
        if (data.Length == 5)
        {
            string courseName = data[1];
            string filter = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }
    private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                Data.FilterAndTake(courseName, filter);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                if (hasParsed)
                {
                    Data.FilterAndTake(courseName, filter, studentsToTake);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
        }
    }
    private static void TryOrderAndTake(string input, string[] data)
    {
        if (data.Length == 5)
        {
            string courseName = data[1];
            string comparison = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }

    private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                Data.OrderAndTake(courseName, comparison);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                if (hasParsed)
                {
                    Data.OrderAndTake(courseName, comparison, studentsToTake);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
        }
    }

    private static void TryDownloadRequestedFileAsync(string input, string[] data)
    {
        if (data.Length == 2)
        {
            string url = data[1];
            DownloadManager.DownloadAsync(url);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }
    private static void TryDownloadRequestedFile(string input, string[] data)
    {
        if (data.Length == 2)
        {
            string url = data[1];
            DownloadManager.Download(url);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }
}
