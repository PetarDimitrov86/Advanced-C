using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
public static class Data
{
    public static bool isDataInitialized = false;
    private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

    public static void InitializeData(string fileName)
    {
        if (!isDataInitialized)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            ReadData(fileName);
        }
        else
            OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
    }
    private static void ReadData(string fileName)
    {
        string path = SessionData.currentPath + "\\" + fileName;
        if (File.Exists(path))
        {
            string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            Regex rgx = new Regex(pattern);
            string[] allInputLines = File.ReadAllLines(path);
            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                {
                    //string[] data = allInputLines[line].Split(' ');
                    Match currentMatch = rgx.Match(allInputLines[line]);
                    string courseName = currentMatch.Groups[1].Value;
                    string username = currentMatch.Groups[2].Value;
                    int studentScoreOnTask;
                    bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);
                    if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                    {
                        if (!studentsByCourse.ContainsKey(courseName))
                            studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                        if (!studentsByCourse[courseName].ContainsKey(username))
                            studentsByCourse[courseName].Add(username, new List<int>());
                    }
                    studentsByCourse[courseName][username].Add(studentScoreOnTask);
                }
            }
            // TODO variable names? which are used, and which aren't
            //string[] tokens = fileName.Split(' ');
            //string course = tokens[0];
            //string student = tokens[1];
            //int mark = int.Parse(tokens[2]);            
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
        }
        isDataInitialized = true;
        OutputWriter.WriteMessageOnNewLine("Data read!");
    }
    private static bool IsQueryForCoursePossible(string courseName)
    {
        if (isDataInitialized)
        {
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
        }
        else
            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
        return false;
    }
    private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
    {
        if (isDataInitialized)
        {
            if (studentsByCourse.ContainsKey(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
        }
        else
            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
        return false;
    }
    public static void GetStudentScoresFromCourse(string courseName, string username)
    {
        if (IsQueryForStudentPossible(courseName, username))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
        }
    }
    public static void GetAllStudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageOnNewLine($"{courseName}:");
            foreach (var studentMarksEntry in studentsByCourse[courseName])
            {
                OutputWriter.PrintStudent(studentMarksEntry);
            }
        }
    }
}