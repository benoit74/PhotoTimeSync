using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync.Logging.Configuration
{

    public class Switches
        : ConfigurationElementCollection
    {
        public Switch this[int index]
        {
            get
            {
                return base.BaseGet(index) as Switch;
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

        public new Switch this[string responseString]
        {
            get { return (Switch)BaseGet(responseString); }
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
            return new Switch();
        }

        
        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((Switch)element).DisplayName;
        }
    }
}
