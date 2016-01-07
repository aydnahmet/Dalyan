using Dalyan.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dalyan.Entities.Models
{
    [Serializable]
    public class ExceptionLog : Exception
    {
        private LogType _logtype;
        private LogLevel _loglevel;
        private Exception _innerexception;
        private String _message;

        public LogType LogType
        {
            get { return this._logtype; }
        }

        public LogLevel LogLevel
        {
            get { return this._loglevel; }
        }

        public Exception Ex
        {
            get { return this._innerexception; }
        }

        public String ExMessage
        {
            get { return this._message; }
        }

        public ExceptionLog()
            : base()
        { }

        public ExceptionLog(LogType logtype, LogLevel loglevel, Exception ex, string message)
            : base()
        {
            this._logtype = logtype;
            this._loglevel = loglevel;
            this._innerexception = ex;
            this._message = message;
        }

        public ExceptionLog(string message)
            : base(message)
        { }

        public ExceptionLog(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public ExceptionLog(string message, Exception innerException)
            : base(message, innerException)
        { }

        public ExceptionLog(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        { }

        protected ExceptionLog(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
