using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLog.Tools;
using System.IO;
using System.Threading;

namespace TLog.Log
{
    public class Log
    {
        #region Private Member Variables

        private string filename;
        private string filepath;

        #endregion

        #region Properties

        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
            }
        }

        public string Filepath
        {
            get
            {
                return filepath;
            }

            set
            {
                filepath = value;
            }
        }

        #endregion

        #region Methods

        public Log(string filename)
        {
            Filename = filename;
            Filepath = Utility.ToFileName(filename);
            if (File.Exists(Filepath))
            {
                var stream = File.AppendText(Filepath);
                stream.Write(String.Format(@" -- {0} --", Utility.GetEntryText()));
            }
            else
            {
                File.Create(Filepath);
                var stream = File.AppendText(Filepath);
                stream.Write(String.Format(@" -- {0} --", Utility.GetEntryText()));
            }
        }

        public void WriteLogLine(string text)
        {
            StringWriter write = new StringWriter();
            string time = Utility.GetEntryText();
            string Log = String.Format(@"\n\r{0} :: {1}", time, text);
            write.Write(Log);
        }

        public void WriteLine(string text)
        {
            StringWriter write = new StringWriter();
            string log = String.Format(@"\n\r {0}", text);
            write.Write(log);
        }

        public void DeleteLog()
        {
            File.Delete(this.Filepath);
        }

        public async void ClearLog()
        {
            await Task.Factory.StartNew(() =>
           {
               var path = Filepath;
               File.Delete(path);
               Thread.Sleep(200);
               File.Create(path);
           });
        }

        public static void CreateErrorLog(string filename, string text)
        {
            string filepath = Utility.ToFileName(filename);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            File.Create(filepath);
            var stream = File.AppendText(filepath);

            stream.Write(String.Format("ERROR :: {0}", text));
        }
        #endregion


    }
}
