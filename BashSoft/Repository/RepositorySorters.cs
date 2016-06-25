﻿using System;
using System.Collections.Generic;
using System.Linq;
class RepositorySorters
{
    public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
    {
        comparison = comparison.ToLower();
        if (comparison == "ascending")
        {
            PrintStudents(wantedData.OrderBy(x => x.Value.Sum())
                                    .Take(studentsToTake)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value));
        }
        else if (comparison == "descending")
        {
            PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum())
                                    .Take(studentsToTake)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value));
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
        }
    }
    private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
    {
        foreach (var keyValuePair in studentsSorted)
        {
            OutputWriter.PrintStudent(keyValuePair);
        }
    }
}
//    private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake,
//        Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
//    {
//        var result = GetSortedStudents(wantedData, studentsToTake, comparisonFunc);
//        foreach (var item in result)
//        {
//            OutputWriter.PrintStudent(item);
//        }

//    }
//    private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted,
//        int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> Comparison)
//    {
//        int valuesTaken = 0;
//        Dictionary<string, List<int>> studentsSorted = new Dictionary<string, List<int>>();
//        KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
//        bool isSorted = false;

//        while (takeCount != valuesTaken)   //changed from true to takeCount != valuesTaken
//        {
//            isSorted = true;
//            foreach (var studentWithScore in studentsWanted)
//            {
//                if (!String.IsNullOrEmpty(nextInOrder.Key))
//                {
//                    int comparisonResult = Comparison(studentWithScore, nextInOrder);
//                    if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentWithScore.Key))
//                    {
//                        nextInOrder = studentWithScore;
//                        isSorted = false;
//                    }
//                }
//                else
//                {
//                    if (!studentsSorted.ContainsKey(studentWithScore.Key))
//                    {
//                        nextInOrder = studentWithScore;
//                        isSorted = false;
//                    }
//                }
//            }
//            if (!isSorted)
//            {
//                studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
//                valuesTaken++;
//                nextInOrder = new KeyValuePair<string, List<int>>();
//            }
//        }
//        return studentsSorted;
//    }

//    private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
//        KeyValuePair<string, List<int>> secondValue)
//    {
//        int totalOfFirstMarks = 0;
//        foreach (int i in firstValue.Value)
//        {
//            totalOfFirstMarks += i;
//        }
//        int totalOfSecondMarks = 0;
//        foreach (int i in secondValue.Value)
//        {
//            totalOfSecondMarks += i;
//        }
//        return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
//    }
//    private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue,
//        KeyValuePair<string, List<int>> secondValue)
//    {
//        int totalOfFirstMarks = 0;
//        foreach (int i in firstValue.Value)
//        {
//            totalOfFirstMarks += i;
//        }
//        int totalOfSecondMarks = 0;
//        foreach (int i in secondValue.Value)
//        {
//            totalOfSecondMarks += i;
//        }
//        return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
//    }
//}