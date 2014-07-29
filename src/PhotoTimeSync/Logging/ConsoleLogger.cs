using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public class ConsoleLogger : ILogger
    {

        public void Log(DateTime date, int? customerID, int? customerUserID, System.Diagnostics.TraceLevel level, string category, string step, string source, string message, string data)
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", DateTime.Now, customerID, customerUserID, level, category, step, source, message, data));
        }
    }
}
