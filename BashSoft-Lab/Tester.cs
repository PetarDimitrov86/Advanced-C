using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public static class Tester
{
    public static void CompareContent(string userOutputPath, string expectedOutpuPath)
    {
        OutputWriter.WriteMessageOnNewLine("Reading files...");
        string mismatchPath = GetMismatchPath(expectedOutpuPath);

        string[] actualOutputLines = File.ReadAllLines(userOutputPath);
        string[] expectedOutputLines = File.ReadAllLines(expectedOutpuPath);

        bool hasMismatch;
        string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

        PrintOutput(mismatches, hasMismatch, mismatchPath);
        OutputWriter.WriteMessageOnNewLine("Files Read!");
    }
    private static string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = directoryPath + @"\Mismatches.txt";
        return finalPath;
    }
    private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
    {
        hasMismatch = false;
        string output = string.Empty;

        string[] mismatches = new string[actualOutputLines.Length];
        OutputWriter.WriteMessageOnNewLine("Comparing files...");

        for (int index = 0; index < actualOutputLines.Length; index++)
        {
            string actualLine = actualOutputLines[index];
            string expectedLine = expectedOutputLines[index];

            if (!actualLine.Equals(expectedLine))
            {
                output = string.Format("Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"", index, expectedLine, actualLine);
                output += Environment.NewLine;
                hasMismatch = true;
            }
            else
            {
                output = actualLine;
                output += Environment.NewLine;
            }
            mismatches[index] = output;
        }
        return mismatches;
    }
    private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }
            File.WriteAllLines(mismatchesPath, mismatches);
            return;
        }
        else
        {
            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }
    }
}