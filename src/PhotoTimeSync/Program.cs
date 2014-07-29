using PhotoTimeSync.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTimeSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = LogConfig.GetConfig();
            foreach(RotatingLog item in config.RotatingLogs)
            {
                List<LogSwitch> switches = new List<LogSwitch>();
                foreach(Switch sw in item.Switches)
                {
                    LogSwitch s = new LogSwitch(sw.DisplayName, sw.Description);
                    s.Category = sw.Category;
                    s.Level = sw.Level;
                    s.Step = sw.Step;
                    s.CustomerID = sw.CustomerID;
                    s.CustomerUserID = sw.CustomerUserID;
                    switches.Add(s);
                }
                LogManager.Add(
                    new RotatingFileLogger(item.BaseFilePath, item.NbRotatingFiles, item.EachFileMaxSize, item.MaxLogEntriesPendingInMemory),
                    switches);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
