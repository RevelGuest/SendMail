using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SendMail.common
{
    public class LogHelper
    {
        public static void WriteLog(string Info)
        {
            WriteLog(Info, null);
        }

        public static void WriteLog(string Info, Exception ex)
        {
            string dir = System.Environment.CurrentDirectory+"\\log";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            Info = DateTime.Now.ToString() + " " + Info + System.Environment.NewLine;

            if (ex != null)
            {
                Info += ex.ToString() + System.Environment.NewLine;
            }

            string logFilePath = dir + "\\log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            File.AppendAllText(logFilePath, Info);
        }
    }
}
