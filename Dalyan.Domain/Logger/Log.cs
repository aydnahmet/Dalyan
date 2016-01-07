using System;
using System.Diagnostics;
using System.Linq;
using Dalyan.Entities.Enumerations;
using Dalyan.Entities;
using Dalyan.Db;
using Dalyan.Entities.Models;
using Dalyan.Entities.Interfaces;
using System.Configuration;
using Dalyan.Entities.Helper.IO;

namespace Dalyan.Domain.Logger
{
    public class Log : ILog
    {
        private readonly DbEntities _db;
        public Log()
        {
            _db = new DbEntities();
        }

        public void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message)
        {
            WriteLog(logtype, loglevel, ex, message);
        }

        public void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message, CurrentUser currentUser)
        {
            WriteLog(logtype, loglevel, ex, message, currentUser);
        }
        private void WriteLog(LogType logtype, LogLevel loglevel, Exception ex, String message, CurrentUser currentUser)
        {
            try
            {
                Dalyan.Db.LogDatabase log = new Dalyan.Db.LogDatabase();
                log.Comment = message;
                log.ExceptionString = ex.ToString();
                log.LogDate = DateTime.Now;
                log.LogLevel = loglevel.ToString();
                log.LogType = logtype.ToString();
                if (currentUser != null) log.UserId = currentUser.UserID;
                log.IsDeleted = false;
                _db.LogDatabase.Add(log);
                _db.SaveChanges();
            }
            catch (Exception exLog)
            {
                WriteLogToFile(logtype, loglevel, ex, message, exLog);
            }
        }

        private void WriteLog(LogType logtype, LogLevel loglevel, Exception ex, String message)
        {
            try
            {
                Dalyan.Db.LogDatabase log = new Dalyan.Db.LogDatabase();
                log.Comment = message;
                log.ExceptionString = ex.ToString();
                log.LogDate = DateTime.Now;
                log.LogLevel = loglevel.ToString();
                log.LogType = logtype.ToString();
                log.IsDeleted = false;
                _db.LogDatabase.Add(log);
                _db.SaveChanges();
            }
            catch (Exception exLog)
            {
                WriteLogToFile(logtype, loglevel, ex, message, exLog);
            }
        }

        private void WriteLogToFile(LogType logtype, LogLevel loglevel, Exception ex, String message, Exception exlog)
        {
            string content = "Log \r\n" + DateTime.Now + "\r\n" + loglevel.ToString() + "\r\n" + logtype.ToString() + "\r\n Exception:" + ex.ToString() + "\r\n message:" + message + "\r\n Extra Log :" + exlog.ToString();
            string filename = ConfigurationManager.AppSettings["logPath"] + DateTime.Now.Ticks.ToString() + ".txt";
            FileHelper.WriteFile(content, filename);
        }
    }
}
