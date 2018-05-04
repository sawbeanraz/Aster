using Aster.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Logging {
    public class Log : BaseEntity {
        public int LogLevelId { get; set; }

        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }

        public string Ip { get; set; }

        public string PageUrl { get; set; }

        public string ReferrerUrl { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public LogLevel LogLevel {
            get {
                return (LogLevel)LogLevelId;
            } set {
                LogLevelId = (int)value;
            }
        }

        public string Reference { get; set; }       //Logging reference
    }
}
