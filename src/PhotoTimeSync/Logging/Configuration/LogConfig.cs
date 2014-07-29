using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync.Logging.Configuration
{
    public class LogConfig : ConfigurationSection
    {

        public static LogConfig GetConfig()
        {
            return (LogConfig)System.Configuration.ConfigurationManager.GetSection("logConfig") ?? new LogConfig();
        }

        [System.Configuration.ConfigurationProperty("rotatingLogs")]
        [ConfigurationCollection(typeof(RotatingLogs), AddItemName = "rotatingLog")]
        public RotatingLogs RotatingLogs
        {
            get
            {
                object o = this["rotatingLogs"];
                return o as RotatingLogs;
            }
        }

    }
}
