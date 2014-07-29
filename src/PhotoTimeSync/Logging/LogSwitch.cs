using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{

    /// <summary>
    /// A class allowing to put on a type of log event
    /// </summary>
    public class LogSwitch : Switch
    {

        /// <summary>
        /// Level of current switch
        /// </summary>
        public TraceLevel Level { get; set; }

        private int? _CustomerID;
        /// <summary>
        /// Specific customerID (if null, all customerID)
        /// </summary>
        public int? CustomerID 
        { 
            get
            {
                return _CustomerID;
            }
            set 
            {
                _CustomerID = value;
                AllCustomerID = (value == null);
            }
        }

        private int? _CustomerUserID;
        /// <summary>
        /// Specific customerUserID (if null, all customerUserID)
        /// </summary>
        public int? CustomerUserID
        {
            get
            {
                return _CustomerUserID;
            }
            set
            {
                _CustomerUserID = value;
                AllCustomerUserID = (value == null);
            }
        }

        public string _Category;
        /// <summary>
        /// Specific Category (if null, all Category)
        /// </summary>
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
                AllCategory = string.IsNullOrWhiteSpace(value);
            }
        }

        public string _Step;
        /// <summary>
        /// Specific Step (if null, all Step)
        /// </summary>
        public string Step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;
                AllStep = string.IsNullOrWhiteSpace(value);
            }
        }

        /// <summary>
        /// All customerID matches current switch
        /// </summary>
        public bool AllCustomerID { get; set; }
        /// <summary>
        /// All customerUserID matches current switch
        /// </summary>
        public bool AllCustomerUserID { get; set; }
        /// <summary>
        /// All category matches current switch
        /// </summary>
        public bool AllCategory { get; set; }
        /// <summary>
        /// All step matches current switch
        /// </summary>
        public bool AllStep { get; set; }
        
        public LogSwitch(string displayName, string description) :
         base(displayName, description)
        {

        }

        /// <summary>
        /// Indicates if switch is on for a given event
        /// </summary>
        /// <param name="eventLevel">Level of given event</param>
        /// <param name="eventCategory">Category of given event</param>
        /// <param name="eventStep">Step of given event</param>
        /// <param name="eventCustomerID">CustomerID of given event</param>
        /// <param name="eventCustomerUserID">CustomerUserID of given event</param>
        /// <returns>true if switch is on for the given event</returns>
        public bool IsOn(TraceLevel eventLevel, string eventCategory, string eventStep, int? eventCustomerID, int? eventCustomerUserID)
        {
            if (eventLevel > this.Level)
                return false;

            if (!AllCategory && eventCategory != null && Category != null && eventCategory != Category)
                return false;

            if (!AllStep && eventStep != null && Step != null && eventStep != Step)
                return false;

            if (!AllCustomerID && eventCustomerID != null && CustomerID != null && eventCustomerID != CustomerID)
                return false;

            if (!AllCustomerUserID && eventCustomerUserID != null && CustomerUserID != null && eventCustomerUserID != CustomerUserID)
                return false;
            
            return true;
        }

        /// <summary>
        /// Indicates if at least one switch is on for a given event
        /// </summary>
        /// <param name="switches">List of switches</param>
        /// <param name="eventLevel">Level of given event</param>
        /// <param name="eventCategory">Category of given event</param>
        /// <param name="eventStep">Step of given event</param>
        /// <param name="eventCustomerID">CustomerID of given event</param>
        /// <param name="eventCustomerUserID">CustomerUserID of given event</param>
        /// <returns>true if at least one switch is on for the given event or if the list of switches is empty</returns>
        public static bool IsOn(IEnumerable<LogSwitch> switches, TraceLevel eventLevel, string eventCategory, string eventStep, int? messageCustomerID, int? eventCustomerUserID)
        {
            // Always on if no switches configured
            if (switches == null || switches.Count() == 0)
                return true;

            foreach(LogSwitch sw in switches)
            {
                if (sw.IsOn(eventLevel, eventCategory, eventStep, messageCustomerID, eventCustomerUserID))
                    return true;
            }

            return false;

        }


    }
}
