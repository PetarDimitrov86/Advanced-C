using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
public class Launcher
{
    public static void Main(string[] args)
    {
        // Test inputs from previous versions
        //IOManager.TraverseDirectory(1);
        //Data.InitializeData();
        //Data.GetAllStudentsFromCourse("Unity");
        //Data.GetStudentScoresFromCourse("Unity", "Ivan");
        //Tester.CompareContent(@"C:\Users\Petar\Downloads\Advanced C#\4. Advanced-CSharp-Exception-Handling\actual.txt", @"C:\Users\Petar\Downloads\Advanced C#\4. Advanced-CSharp-Exception-Handling\expected.txt");
        //IOManager.CreateDirectoryInCurrentFolder("*2");
        //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
        //IOManager.TraverseDirectory(20);
        InputReader.StartReadingCommands();
    }
}
