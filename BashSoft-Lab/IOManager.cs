using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public static class IOManager
{
    public static void TraverseDirectory(int depth)
    {
        OutputWriter.WriteEmptyLine();
        int initialIdentation = SessionData.currentPath.Split('\\').Length;
        Queue<string> subFolders = new Queue<string>();
        subFolders.Enqueue(SessionData.currentPath);

        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            int identation = currentPath.Split('\\').Length - initialIdentation;
            if (depth - identation < 0)
            {
                break;
            }
            OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
            foreach (var file in Directory.GetFiles(currentPath))
            {
                int indexOfLastSlash = file.LastIndexOf("\\");
                string fileName = file.Substring(indexOfLastSlash);
                OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
            }
            foreach (string directoryPath in Directory.GetDirectories(currentPath))
                subFolders.Enqueue(directoryPath);
        }
    }
    public static void CreateDirectoryInCurrentFolder(string name)
    {
        string path = Directory.GetCurrentDirectory() + "\\" + name;
        Directory.CreateDirectory(name);
    }
}
