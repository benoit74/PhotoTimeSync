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

            // Log initialization has to be done asap (otherwise we won't be able to log initialization errors ...)
            var config = LogConfig.GetConfig();
            foreach (RotatingLog item in config.RotatingLogs)
            {
                List<LogSwitch> switches = new List<LogSwitch>();
                foreach (Switch sw in item.Switches)
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

            // Init logs
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "Program", "Init", "***************************", "");
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "Program", "Init", "PhotoTimeSync", "v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "Program", "Init", "***************************", "");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Upgrade setting file if necessary (application version change)
            SettingsUtil.DoUpgrade(Properties.Settings.Default);

            // Set culture based on user setting
            PhotoTimeSync.Labels.Labels.Culture = new System.Globalization.CultureInfo(Properties.Settings.Default.UserLanguage);

            Application.Run(new MainForm());
        }
    }
}
