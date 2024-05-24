using System;
using System.IO;

namespace FizzBuzz.Api.Infrastructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: INFO - {message}{Environment.NewLine}");
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: ERROR - {message}. Exception: {ex}{Environment.NewLine}");
        }
    }
}
