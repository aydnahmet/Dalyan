using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalyan.Entities.Helper.IO
{
    public static class FileHelper
    {
        public static void WriteFile(string content, string path)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                file.WriteLine(content);
                file.Close();
            }
            catch
            {

            }
        }

        public static bool FileExist(string path)
        {
            return File.Exists(path);
        }
    }
}