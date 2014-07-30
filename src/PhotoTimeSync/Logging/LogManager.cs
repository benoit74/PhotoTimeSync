using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    
    /// <summary>
    /// Static class allowing to log everywhere in the code.
    /// Holds a list of loggers with their associated switches
    /// used to put on/off log events
    /// </summary>
    public class LogManager
    {

        
        [ThreadStatic]
        private static int? _CustomerID;
        private static int? _CustomerUserID;

        public static void SetDefault(int? CustomerID, int? CustomerUserID)
        {
            _CustomerID = CustomerID;
            _CustomerUserID = CustomerUserID;
        }

        private static List<LoggerWithSwitches> Loggers { get; set; }

        static LogManager()
        {
            Loggers = new List<LoggerWithSwitches>();
        }

        /// <summary>
        /// Adds a new logger to this manager
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="switches">List of switches</param>
        public static void Add(ILogger logger, List<LogSwitch> switches)
        {
            Loggers.Add(new LoggerWithSwitches(logger, switches));
        }

        /// <summary>
        /// Logs an event with default current customerID and customerUserID
        /// </summary>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArgs">Data formating arguments</param>
        public static void Log(TraceLevel level, string category, string step, string message, string data, params object[] dataArgs)
        {
            Log(_CustomerID, _CustomerUserID, level, category, step, message, new FutureStringFormatterArrayData(data, dataArgs));
        }

        /// <summary>
        /// Logs an event with multiple data arguments
        /// </summary>
        /// <param name="customerID">Customer ID (optionnal)</param>
        /// <param name="customerUserID">Customer User ID (optionnal)</param>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArgs">Data formating arguments</param>
        public static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, string data, params object[] dataArgs)
        {
            Log(customerID, customerUserID, level, category, step, message, new FutureStringFormatterArrayData(data, dataArgs));
        }

        /// <summary>
        /// Logs an event with one data argument and with default current customerID and customerUserID
        /// </summary>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        public static void Log(TraceLevel level, string category, string step, string message, string data, object dataArg0)
        {
            Log(_CustomerID, _CustomerUserID, level, category, step, message, new FutureStringFormatterOneData(data, dataArg0));
        }

        /// <summary>
        /// Logs an event with one data argument
        /// </summary>
        /// <param name="customerID">Customer ID (optionnal)</param>
        /// <param name="customerUserID">Customer User ID (optionnal)</param>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        public static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, string data, object dataArg0)
        {
            Log(customerID, customerUserID, level, category, step, message, new FutureStringFormatterOneData(data, dataArg0));
        }

        /// <summary>
        /// Logs an event with two data argument and with default current customerID and customerUserID
        /// </summary>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        /// <param name="dataArg1">>Data formating argument 1</param>
        public static void Log(TraceLevel level, string category, string step, string message, string data, object dataArg0, object dataArg1)
        {
            Log(_CustomerID, _CustomerUserID, level, category, step, message, new FutureStringFormatterTwoData(data, dataArg0, dataArg1));
        }

        /// <summary>
        /// Logs an event with two data argument
        /// </summary>
        /// <param name="customerID">Customer ID (optionnal)</param>
        /// <param name="customerUserID">Customer User ID (optionnal)</param>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        /// <param name="dataArg1">>Data formating argument 1</param>
        public static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, string data, object dataArg0, object dataArg1)
        {
            Log(customerID, customerUserID, level, category, step, message, new FutureStringFormatterTwoData(data, dataArg0, dataArg1));
        }

        /// <summary>
        /// Logs an event with three data argument and with default current customerID and customerUserID
        /// </summary>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        /// <param name="dataArg1">>Data formating argument 1</param>
        /// <param name="dataArg2">>Data formating argument 2</param>
        public static void Log(TraceLevel level, string category, string step, string message, string data, object dataArg0, object dataArg1, object dataArg2)
        {
            Log(_CustomerID, _CustomerUserID, level, category, step, message, new FutureStringFormatterThreeData(data, dataArg0, dataArg1, dataArg2));
        }

        /// <summary>
        /// Logs an event with three data argument
        /// </summary>
        /// <param name="customerID">Customer ID (optionnal)</param>
        /// <param name="customerUserID">Customer User ID (optionnal)</param>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        /// <param name="dataArg0">>Data formating argument 0</param>
        /// <param name="dataArg1">>Data formating argument 1</param>
        /// <param name="dataArg2">>Data formating argument 2</param>
        public static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, string data, object dataArg0, object dataArg1, object dataArg2)
        {
            Log(customerID, customerUserID, level, category, step, message, new FutureStringFormatterThreeData(data, dataArg0, dataArg1, dataArg2));
        }

        /// <summary>
        /// Logs an event without data argument and with default current customerID and customerUserID
        /// </summary>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        public static void Log(TraceLevel level, string category, string step, string message, string data)
        {
            Log(_CustomerID, _CustomerUserID, level, category, step, message, new FutureStringFormatterDummy(data));
        }

        /// <summary>
        /// Logs an event without data argument
        /// </summary>
        /// <param name="customerID">Customer ID (optionnal)</param>
        /// <param name="customerUserID">Customer User ID (optionnal)</param>
        /// <param name="level">Level of current log event</param>
        /// <param name="category">Category</param>
        /// <param name="step">Step</param>
        /// <param name="message">Message</param>
        /// <param name="data">Data</param>
        public static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, string data)
        {
            Log(customerID, customerUserID, level, category, step, message, new FutureStringFormatterDummy(data));
        }

        private static void Log(int? customerID, int? customerUserID, TraceLevel level, string category, string step, string message, IFutureStringFormatter data)
        {
            string source = string.Format("{0}|{1:0000}", IPAddressUtil.GetInterNetworkIPAddress(false), System.Threading.Thread.CurrentThread.ManagedThreadId);
            DateTime date = DateTime.Now;
            foreach(LoggerWithSwitches ls in Loggers)
            {
                if (LogSwitch.IsOn(ls.Switches, level, category, step, customerID, customerUserID))
                    ls.Logger.Log(date, customerID, customerUserID, level, category, step, source, message, data.ToString());
            }
        }

    }
}
