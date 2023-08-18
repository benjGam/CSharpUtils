using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.File
{
    public static class FileInfoExtensions
    {
        public static string GetDirectoyPath(this FileInfo fileInfo) => fileInfo.Directory != null ? fileInfo.Directory.FullName : string.Empty;
        public static string GetDirectoryName(this FileInfo fileInfo) => fileInfo.DirectoryName != null ? fileInfo.DirectoryName! : string.Empty;
        public static string ReadAllText(this FileInfo fileInfo)
        {
            string fileContent = string.Empty;
            using (StreamReader fileStream =  new StreamReader(fileInfo.OpenRead()))
                fileContent = fileStream.ReadToEnd();
            return fileContent;
        }
        public static Encoding GetEncoding(this FileInfo fileInfo)
        {
            Encoding fileEncoding;
            using (StreamReader fileStream = new StreamReader(fileInfo.OpenRead()))
            {
                fileStream.Peek();
                fileEncoding = fileStream.CurrentEncoding;
            }
            return fileEncoding;
        }

    }
}
