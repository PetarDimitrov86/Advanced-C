using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        if (Directory.Exists(path))
        {
            string[] allInputLines = File.ReadAllLines(path);
            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]))
                {
                    string[] data = allInputLines[line].Split(' ');
                }
            }
            // TODO variable names? which are used, and which aren't
            string[] tokens = fileName.Split(' ');
            string course = tokens[0];
            string student = tokens[1];
            int mark = int.Parse(tokens[2]);

            if (!studentsByCourse.ContainsKey(course))
                studentsByCourse.Add(course, new Dictionary<string, List<int>>());
            if (!studentsByCourse[course].ContainsKey(student))
                studentsByCourse[course].Add(student, new List<int>());

            studentsByCourse[course][student].Add(mark);
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