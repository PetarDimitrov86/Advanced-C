using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }
}
public class Student
{
    public string StudentName { get; set; }
    public string FacultyNum { get; set; }
}
class StudentsJoinedToSpecialties
{
    static void Main(string[] args)
    {
        string specialties = Console.ReadLine();
        List<StudentSpecialty> specList = new List<StudentSpecialty>();
        while (specialties != "Students:")
        {
            string[] data = specialties.Split();
            StudentSpecialty tempSpec = new StudentSpecialty();
            tempSpec.SpecialtyName = data[0] + " " + data[1];
            tempSpec.FacultyNumber = data[2];
            specList.Add(tempSpec);
            specialties = Console.ReadLine();
        }
        List<Student> studFac = new List<Student>();
        string facultyStudents = Console.ReadLine();
        while (facultyStudents != "END")
        {
            string[] data = facultyStudents.Split();
            Student tempStud = new Student();
            tempStud.FacultyNum = data[0];
            tempStud.StudentName = data[1] + " " + data[2];
            studFac.Add(tempStud);
            facultyStudents = Console.ReadLine();
        }
        var result = studFac.Join(specList,
            a => a.FacultyNum,
            b => b.FacultyNumber,
            (a, b) => new {a.StudentName, a.FacultyNum, b.SpecialtyName}).OrderBy(x => x.StudentName);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.StudentName} {item.FacultyNum} {item.SpecialtyName}");
        }
    }
}