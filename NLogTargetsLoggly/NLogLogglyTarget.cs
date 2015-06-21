using System.Configuration;
using NLog;
using NLog.Targets;

namespace NLogTargetsLoggly
{
    [Target("Loggly")]
    public sealed class NLogLogglyTarget : TargetWithLayout
    {
        protected override void Write(LogEventInfo logEvent)
        {
            if (logEvent.Properties.ContainsKey("syslog-suppress"))
            {
                return;
            }

            LogEventInfo correctEvent = GetCorrectEvent(logEvent);
            string logEventMessage = Layout.Render(correctEvent);

            LogglyClient client = new LogglyClient(ConfigurationManager.AppSettings["LogglyToken"]);

            client.Log(ConfigurationManager.AppSettings["LogglyTag"], new LogglyEvent
            {
                Level = correctEvent.Level.Name,
                Message = logEventMessage
            });
        }

        public static LogEventInfo GetCorrectEvent(LogEventInfo inboundEventInfo)
        {
            LogEventInfo logEventInfo1 = inboundEventInfo;
            if (inboundEventInfo.Parameters != null && inboundEventInfo.Parameters.Length == 1)
            {
                LogEventInfo logEventInfo2 = inboundEventInfo.Parameters[0] as LogEventInfo;
                if (logEventInfo2 != null)
                {
                    logEventInfo1 = logEventInfo2;
                    logEventInfo1.Level = inboundEventInfo.Level;
                }
            }
            return logEventInfo1;
        }
    }
}
