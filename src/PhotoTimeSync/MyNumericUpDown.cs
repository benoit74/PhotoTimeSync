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
    public partial class MyNumericUpDown : UserControl
    {
        public MyNumericUpDown()
        {
            InitializeComponent();
        }


        [Description("Value"), Category("Data"), DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                txtBox.Text = value.ToString();
                OnValueChanged(this);
            }
        }
        private int _value;


        public delegate void ValueChangedHandler(MyNumericUpDown sender);
        public event ValueChangedHandler ValueChanged;

        private void OnValueChanged(MyNumericUpDown sender)
        {
            if (ValueChanged != null)
                ValueChanged(sender);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Value -= 1;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Value += 1;
        }


    }
}
