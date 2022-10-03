using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            if (!Directory.Exists(inputFolderPath))
                return null;

            var fileInfos = new SortedDictionary<string, List<FileInfo>>();
            var directoryInfo = new DirectoryInfo(inputFolderPath);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (!fileInfos.ContainsKey(file.Extension))
                    fileInfos.Add(file.Extension, new List<FileInfo>());

                fileInfos[file.Extension].Add(file);
            }

            var sb = new StringBuilder();
            foreach (var (extension, files) in 
                     fileInfos.OrderByDescending(extension => extension.Value.Count))
            {
                sb.AppendLine(extension);

                foreach (FileInfo file in files.OrderBy(file => file.Length))
                {
                    sb.AppendLine($"--{file.Name} - {file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText( 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName, textContent);
        }
    }
}
