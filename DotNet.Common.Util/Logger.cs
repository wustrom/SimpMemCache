using System;
using System.Diagnostics;

namespace DotNet.Common.Util
{
    public class Logger
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private static string FormatMessage(string message)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            return string.Format("{0}.{1}: {2}", sf.GetMethod().DeclaringType.Name,
                                 sf.GetMethod().Name, message);
        }

        public static void Error(string info)
        {
            log.Error(FormatMessage(info));
        }

        public static void Error(string info, params object[] args)
        {
            info = string.Format(info, args);
            Error(info);
        }

        public static void Error(string info, Exception ex)
        {
            log.Error(FormatMessage(info), ex);
        }

        public static void Warn(string info)
        {
            log.Warn(FormatMessage(info));
        }

        public static void Warn(string info, params object[] args)
        {
            info = string.Format(info, args);
            Warn(info);
        }

        public static void Warn(string info, Exception ex)
        {
            log.Warn(FormatMessage(info), ex);
        }

        public static void Info(string info)
        {
            log.Info(FormatMessage(info));
        }

        public static void Info(string info, params object[] args)
        {
            Info(string.Format(info, args));
        }

        public static void Info(string info, Exception ex)
        {
            log.Info(FormatMessage(info), ex);
        }

        public static void Debug(string info)
        {
            log.Debug(FormatMessage(info));
        }

        public static void Debug(string info, params object[] args)
        {
            Debug(string.Format(info, args));
        }

        public static void Debug(string info, Exception ex)
        {
            log.Debug(FormatMessage(info), ex);
        }

        public static void Fatal(string info)
        {
            log.Fatal(FormatMessage(info));
        }

        public static void Fatal(string info, params object[] args)
        {
            Fatal(string.Format(info, args));
        }
    }
}