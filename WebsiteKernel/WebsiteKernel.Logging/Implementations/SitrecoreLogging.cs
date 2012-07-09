using System;
using log4net;

namespace WebsiteKernel.Logging.Implementations
{
    public class SitrecoreLogging:Logger
    {
        private static readonly ILog Logger = LogManager.GetLogger("Website.Diagnostics.Log");

        public override LoggerInformation Info(string message)
        {
            var loggerInformation = new LoggerInformation(message, GetGroupErrorCode());
            Logger.Info(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, message));

            AddLoggerInformation(loggerInformation);

            return loggerInformation;
        }

        public override void Timing(TimeSpan elapsed, string codeTimedKey)
        {
            Logger.Info(String.Format("{0} took {1}ms", codeTimedKey, elapsed.TotalMilliseconds));
            if (!LastTime.ContainsKey(codeTimedKey))
            {
                LastTime.Add(codeTimedKey, elapsed);
            }
            else
            {
                Logger.Info(String.Format("{0} last time it took {1}ms, difference of {2}ms", codeTimedKey, LastTime[codeTimedKey].TotalMilliseconds, (elapsed.TotalMilliseconds - LastTime[codeTimedKey].TotalMilliseconds)));
                LastTime[codeTimedKey] = elapsed;
            }
        }

        public override LoggerInformation Warning(string message, Exception ex = null)
        {
            var loggerInformation = new LoggerInformation(message, GetGroupErrorCode());
            if (ex == null)
            {
                Logger.Warn(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, message));
            }
            else
            {
                Logger.Warn(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, message), ex);
            }

            AddLoggerInformation(loggerInformation);

            return loggerInformation;
        }

        public override LoggerInformation Error(string message, Exception ex = null)
        {
            var loggerInformation = new LoggerInformation(message, GetGroupErrorCode());
            if (ex == null)
            {
                Logger.Error(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, message));
            }
            else
            {
                Logger.Error(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, message), ex);
            }

            AddLoggerInformation(loggerInformation);

            return loggerInformation;
        }

        public override LoggerInformation DataIssue(object o, string message)
        {
            string logMessage = String.Format("Issue with object: {0}", GetObjectInfoamtion(o));
            var loggerInformation = new LoggerInformation(logMessage, GetGroupErrorCode());
            Logger.Info(string.Format("{0}-{1}-{2}", loggerInformation.GroupErrorCode, loggerInformation.ErrorCode, logMessage));

            AddLoggerInformation(loggerInformation);
            return loggerInformation;
        }
    }
}
