using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync.Logging.Configuration
{
    public class Switch : ConfigurationElement 
    {

        [ConfigurationProperty("displayName", IsRequired = true)]
        public string DisplayName
        {
            get
            {
                return this["displayName"] as string;
            }
        }
        [ConfigurationProperty("description", IsRequired = true)]
        public string Description
        {
            get
            {
                return this["description"] as string;
            }
        }
        [ConfigurationProperty("level", IsRequired = true)]
        public TraceLevel Level
        {
            get
            {
                return (TraceLevel)Enum.Parse(typeof(TraceLevel), this["level"].ToString());
            }
        }
        [ConfigurationProperty("customerID", DefaultValue = null, IsRequired = false)]
        public int? CustomerID
        {
            get
            {
                return this["customerID"] as int?;
            }
        }
        [ConfigurationProperty("customerUserID", DefaultValue = null, IsRequired = false)]
        public int? CustomerUserID
        {
            get
            {
                return this["customerUserID"] as int?;
            }
        }
        [ConfigurationProperty("category", DefaultValue = null, IsRequired = false)]
        public string Category
        {
            get
            {
                return this["category"] as string;
            }
        }
        [ConfigurationProperty("step", DefaultValue = null, IsRequired = false)]
        public string Step
        {
            get
            {
                return this["step"] as string;
            }
        }


    }
}
