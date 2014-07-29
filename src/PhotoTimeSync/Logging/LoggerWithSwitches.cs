using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    
    /// <summary>
    /// Class representing an association between a logger and
    /// its switches
    /// </summary>
    class LoggerWithSwitches
    {

        public ILogger Logger { get; set; }
        public List<LogSwitch> Switches { get; set; }

        public LoggerWithSwitches()
        {
            Switches = new List<LogSwitch>();
        }
        public LoggerWithSwitches(ILogger logger, List<LogSwitch> switches)
        {
            Logger = logger;
            Switches = switches;
        }

        

    }
}
