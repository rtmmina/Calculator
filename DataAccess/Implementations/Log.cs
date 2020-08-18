using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interfaces;
using System.IO;

namespace DataAccess.Implementations
{
    public class Log : ILog
    {
        private readonly string errorFile;
        private readonly string infoFile;

        public Log()
        {
            var today = $"{DateTime.Now.Year}{DateTime.Now.ToString("MM")}{DateTime.Now.ToString("dd")}";
            errorFile = $@"C:\Log\{today}_Error.txt";
            infoFile = $@"C:\Log\{today}_Info.txt";

            if (!Directory.Exists(@"C:\Log"))
            {
                Directory.CreateDirectory(@"C:\Log");
            }

            
            if(!File.Exists(errorFile))
            {
                File.Create(errorFile);
            }

            if(!File.Exists(infoFile))
            {
                File.Create(infoFile);
            }
        }
        public void Error(string error)
        {
            WriteText(error, errorFile);
        }

        public void Info(string info)
        {
            WriteText(info, infoFile);
        }

        private void WriteText(string data, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write(data);
                sw.WriteLine();
            }
        }
    }
}
