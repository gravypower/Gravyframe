using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebsiteKernel.Logging
{
    public abstract class Logger
    {
        // a static dictionary so we compare with the time it tool last time
        protected static Dictionary<string, TimeSpan> LastTime = new Dictionary<string, TimeSpan>();

        protected string GetObjectInfoamtion(object o)
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("StackTrace: {0}", Environment.StackTrace));

            var properties = o.GetType().GetProperties();
            //loop though all the properties
            foreach (var property in properties)
            {
                var name = property.Name;
                string value;
                try
                {
                    value = property.GetValue(o, null).ToString();
                }
                catch (Exception ex)
                {
                    value = String.Format("exception getting value: {0}", ex.Message);
                }
                var line = String.Format("Name: {0} value: {1}", name, value);
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public static string GetGroupErrorCode()
        {
            var groupErrorCode = String.Empty;
            if(HttpContext.Current.Items.Contains("GroupErrorCode"))
            {
                groupErrorCode = HttpContext.Current.Items["GroupErrorCode"] as string;
            }
            else
            {
                HttpContext.Current.Items.Add("GroupErrorCode", HttpContext.Current.Request.RawUrl);
            }

            return groupErrorCode;
        }

        protected void AddLoggerInformation(LoggerInformation loggerInformation)
        {
            List<LoggerInformation> loggerInformationList;
            if (HttpContext.Current.Items.Contains("LoggerInformationList"))
            {
                loggerInformationList = HttpContext.Current.Items["LoggerInformationList"] as List<LoggerInformation>;
            }
            else
            {
                loggerInformationList = new List<LoggerInformation>();
                HttpContext.Current.Items.Add("LoggerInformationList", loggerInformationList);
            }
            if (loggerInformationList != null)
            {
                loggerInformationList.Add(loggerInformation);
            }
        }

        public abstract LoggerInformation Info(string message);

        public abstract void Timing(TimeSpan elapsed, string codeTimedKey);

        public abstract LoggerInformation Warning(string message, Exception ex = null);

        public abstract LoggerInformation Error(string message, Exception ex = null);

        public abstract LoggerInformation DataIssue(object o, string message);


    }
}
