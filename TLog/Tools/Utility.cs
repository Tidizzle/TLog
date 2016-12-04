using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TLog.Tools
{
    public static class Utility
    {
        public static string ToFileName(string Filename)
        {
            string result = @"\OregonLog.log";

            try
            {
                result = String.Format(@"\{0}.log", Filename);
            }
            catch (Exception) { }

            return result;
        }

        public static string GetEntryText()
        {
            string Currentdat = DateTime.Today.ToString();
            string currenttime = DateTime.Now.ToShortTimeString();
            string Result = String.Format(@"** {0} :: {1} **", Currentdat, currenttime);
            return Result;
        }

        public static void GetLineReturn(string filepath)
        {
            string log = "\n\r";
            var stream = File.AppendText(filepath);
            stream.Write(log);
        }
    }
}
