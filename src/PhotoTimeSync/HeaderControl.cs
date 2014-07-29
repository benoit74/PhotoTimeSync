using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();
        }

        [Description("Label"), Category("Data"), DefaultValue("Label")]
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                lblMain.Text = value;
            }
        }
        private string _label;

    }
}
