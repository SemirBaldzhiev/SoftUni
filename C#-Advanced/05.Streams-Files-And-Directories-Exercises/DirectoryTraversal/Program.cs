using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();

            string[] fileNames = Directory.GetFiles(directoryPath);

            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = size / 1024.0;

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                filesData[extension].Add(fileName, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDict = filesData.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> result = new List<string>();

            foreach (var item in sortedDict)
            {
                result.Add(item.Key);

                foreach (var fileData in item.Value.OrderBy(x => x.Value))
                {
                    result.Add($"--{fileData.Key} - {fileData.Value}kb");
                }
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");

            File.WriteAllLines(filePath, result);

        }
    }
}
