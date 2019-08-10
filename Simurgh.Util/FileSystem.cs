using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Simurgh.Util
{
    public static class FileSystemExtensionMethods
    {
        public static void WriteToFile(this string content, string fullPath)
        {
            File.WriteAllText(fullPath, content);
        }

        public static void MakeSureFolderExists(this string fileFullPath)
        {
            var info = new FileInfo(fileFullPath);
            Directory.CreateDirectory(info.DirectoryName);
        }

        public static bool FileExists(this string fullPath)
        {
            return File.Exists(fullPath);
        }
    }
}
