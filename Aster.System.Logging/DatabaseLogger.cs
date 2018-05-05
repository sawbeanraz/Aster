using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aster.System.Logging {
    public class DatabaseLogger : ILogger {

        private readonly IRepositoryAsync<Log> _logRepository;

        public DatabaseLogger(IRepositoryAsync<Log> logRepository) {
            _logRepository = logRepository;
        }

        public void ClearLog() {
            var logs = _logRepository.List.ToList();
            foreach(var log in logs) {
                _logRepository.DeleteAsync(log);
            }
        }

        public void DeleteLog(Log log) {
            if(log == null)
                throw new ArgumentNullException(nameof(log));

            _logRepository.DeleteAsync(log);
        }

        public void DeleteLogs(IList<Log> logs) {
            if(logs == null)
                throw new ArgumentNullException(nameof(logs));
            _logRepository.DeleteAsync(logs);
        }

        public async Task<Log> GetLogById(int logId) {
            if(logId == 0)
                return null;

            return await _logRepository.GetByIdAsync(logId);
        }

        public async Task<IList<Log>> GetLogs(DateTime? fromUtc = null, DateTime? toUtc = null, string message = "", LogLevel? logLevel = null) {
            var q = _logRepository.List;
            if(fromUtc.HasValue)
                q = q.Where(l => l.CreatedOnUtc >= fromUtc.Value);

            if(toUtc.HasValue)
                q = q.Where(l => l.CreatedOnUtc <= toUtc.Value);

            if(logLevel.HasValue)
                q = q.Where(l => l.LogLevelId == (int)logLevel.Value);

            if(!string.IsNullOrEmpty(message))
                q = q.Where(l => l.ShortMessage.Contains(message) || l.FullMessage.Contains(message));

            q = q.OrderByDescending(l => l.CreatedOnUtc);

            return await Task.FromResult(q.ToList());
        }

        public async Task<Log> InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", string reference = null) {
            return await _logRepository.InsertAsync(new Log {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                Reference = reference,
                Ip = null,              //todo: _webHelper Class
                PageUrl = null,
                ReferrerUrl = null,
                CreatedOnUtc = DateTime.UtcNow
            });
        }
    }
}
