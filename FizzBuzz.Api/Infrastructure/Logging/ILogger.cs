using System;

namespace FizzBuzz.Api.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message, Exception ex);
    }
}
