using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.File
{
    internal class FileService
    {
        public string? LoadFile(string filePath)
        {
            if(System.IO.File.Exists(filePath))
                return System.IO.File.ReadAllText(filePath);
            else
                return null;
        }

        public void AppendToFile(string filePath, string content) => System.IO.File.AppendAllText(filePath, content);
    }
}
