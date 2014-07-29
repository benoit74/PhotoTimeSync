using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync.Logging.Configuration
{
    public class RotatingLogs
        : ConfigurationElementCollection
    {
        public RotatingLog this[int index]
        {
            get
            {
                return base.BaseGet(index) as RotatingLog;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RotatingLog this[string responseString]
        {
            get { return (RotatingLog)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new RotatingLog();
        }


        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((RotatingLog)element).BaseFilePath;
        }
    }
}
