﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Logging {
    public interface ILogger {

        void DeleteLog(Log log);

        void DeleteLogs(IList<Log> logs);

        void ClearLog();

        Task<IList<Log>> GetLogs(DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = "", LogLevel? logLevel = null); //TODO 

        Task<Log> GetLogById(int logId);

        Task<Log> InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", string reference = null);
    }
}