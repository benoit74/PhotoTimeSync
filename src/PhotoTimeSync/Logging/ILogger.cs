using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public interface ILogger
    {
        void Log(DateTime date, int? customerID, int? customerUserID, TraceLevel level, string category, string step, string source, string message, string data);

    }

}
