using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync.Logging.Configuration
{
    public class RotatingLog : ConfigurationElement
    {
        [System.Configuration.ConfigurationProperty("switches")]
        [ConfigurationCollection(typeof(Switches), AddItemName = "switch")]
        public Switches Switches
        {
            get
            {
                object o = this["switches"];
                return o as Switches;
            }
        }
        [ConfigurationProperty("baseFilePath", IsRequired = true)]
        public string BaseFilePath
        {
            get
            {
                return this["baseFilePath"] as string;
            }
        }
        [ConfigurationProperty("maxLogEntriesPendingInMemory", DefaultValue = "10", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int MaxLogEntriesPendingInMemory
        {
            get
            { return (int)this["maxLogEntriesPendingInMemory"]; }
            set
            { this["maxLogEntriesPendingInMemory"] = value; }
        }
        [ConfigurationProperty("nbRotatingFiles", DefaultValue = "5", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int NbRotatingFiles
        {
            get
            { return (int)this["nbRotatingFiles"]; }
            set
            { this["nbRotatingFiles"] = value; }
        }
        [ConfigurationProperty("eachFileMaxSize", DefaultValue = "1000000", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 10000)]
        public int EachFileMaxSize
        {
            get
            { return (int)this["eachFileMaxSize"]; }
            set
            { this["eachFileMaxSize"] = value; }
        }

    }
}
