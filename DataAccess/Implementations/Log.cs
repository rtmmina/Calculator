using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interfaces;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Implementations
{
    public class Log : ILog
    {
        private readonly string errorFile;
        private readonly string infoFile;
        private readonly IConfiguration _configuration;
        private readonly string directoryName;

        public Log(IConfiguration configuration)
        {
            _configuration = configuration;
            var today = $"{DateTime.Now.Year}{DateTime.Now.ToString("MM")}{DateTime.Now.ToString("dd")}";
            directoryName = _configuration["LoggingFolder"];
            errorFile = Path.Combine(directoryName, $@"{today}_Error.txt");
            infoFile = Path.Combine(directoryName, $@"{today}_Info.txt");

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (!File.Exists(errorFile))
            {
                //File.Create(errorFile);//This method locks the file after creating it,
                using (FileStream fs = File.Create(errorFile))//Work around
                {
                    //you can use the filstream here to put stuff in the file if you want to
                }
            }

            if (!File.Exists(infoFile))
            {
                //File.Create(infoFile);//This method locks the file after creating it.
                using (FileStream fs = File.Create(infoFile))//work around since IDisposal would kick after using.
                {
                    //you can use the filstream here to put stuff in the file if you want to
                }
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
                sw.Flush();
                sw.Close();
            }
        }
    }
}
