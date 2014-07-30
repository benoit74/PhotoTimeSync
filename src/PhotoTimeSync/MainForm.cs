using ExifLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    public partial class MainForm : Form
    {

        private PhotoTimeSynchronizer _sync;
            
        public MainForm()
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "MainForm", "Init", "Creating MainForm", "");
            InitializeComponent();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "Main GUI Init Done", "");
            _sync = new PhotoTimeSynchronizer();
            UserControl1 page1 = new UserControl1(_sync);
            page1.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(page1);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "MainForm", "Init", "UserControl GUI Init Done", "");
        }

    }


}
