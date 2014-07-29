using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    struct LogEntry
    {
        public DateTime date;
        public int? customerID;
        public int? customerUserID;
        public System.Diagnostics.TraceLevel level;
        public string category;
        public string step;
        public string source;
        public string message;
        public string data;
    }
}
