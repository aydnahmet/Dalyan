using Dalyan.Entities.Enumerations;
using Dalyan.Entities.Models;
using System;

namespace Dalyan.Entities.Interfaces
{
    public interface ILog
    {
        void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message, CurrentUser currentUser);
        void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message);
    }
}