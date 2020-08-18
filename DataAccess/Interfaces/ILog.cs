using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ILog
    {
        public void Error(string error);
        public void Info(string info);
    }
}
