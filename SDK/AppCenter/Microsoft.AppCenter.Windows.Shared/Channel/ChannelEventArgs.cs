using System;
using Microsoft.AppCenter.Ingestion.Models;
using System.Collections.Generic;

namespace Microsoft.AppCenter.Channel
{
    public abstract class ChannelEventArgs : EventArgs
    {
        protected ChannelEventArgs(Log log)
        {
            Log = log;
        }
        public Log Log { get; protected set; }
    }
    public class EnqueuingLogEventArgs : ChannelEventArgs
    {
        public EnqueuingLogEventArgs(Log log) : base(log) { }
    }
    public class SendingLogEventArgs : ChannelEventArgs
    {
        public SendingLogEventArgs(Log log) : base(log) { }
    }

    public class FilterLogsEventArgs : EventArgs
    {
        public FilterLogsEventArgs(IList<Log> logs)
        {
            Logs = logs;
        }
        public IList<Log> Logs { get;  set; }
        public IList<Log> FilteredLogs { get; set; }
    }

    public class SentLogEventArgs : ChannelEventArgs
    {
        public SentLogEventArgs(Log log) : base(log) { }
    }
    public class FailedToSendLogEventArgs : ChannelEventArgs
    {
        public FailedToSendLogEventArgs(Log log, Exception exception) : base(log)
        {
            Exception = exception;
        }

        public Exception Exception { get; protected set; }
    }
}
