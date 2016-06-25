using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
public static class DownloadManager
{
    public static void Download(string fileUrl)
    {
        WebClient webClient = new WebClient();
        try
        {
            OutputWriter.WriteMessageOnNewLine("Started downloading: ");
            string nameOfFile = ExtractNameOfFile(fileUrl);
            string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

            webClient.DownloadFile(fileUrl, pathToDownload);

            OutputWriter.WriteMessageOnNewLine("Download complete");
        }
        catch (WebException ex)
        {         
            OutputWriter.DisplayException(ex.Message);
        }
    }

    private static string ExtractNameOfFile(string fileURL)
    {
        int indexOfLastBackslash = fileURL.LastIndexOf("/");
        if (indexOfLastBackslash != -1)
        {
            return fileURL.Substring(indexOfLastBackslash + 1);
        }
        else
        {
            throw new WebException(ExceptionMessages.InvalidPath);
        }
    }

    public static void DownloadAsync(string fileURL)
    {
        Task.Run(() => Download(fileURL));
    }
}
