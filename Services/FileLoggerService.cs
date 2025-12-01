using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "log.txt");

        public void Log(string message, LogType type)
        {
            var logMessage = $"{DateTime.Now} [{type}] {message}";
            File.AppendAllText(_filePath, logMessage + Environment.NewLine);
        }
    }
}
