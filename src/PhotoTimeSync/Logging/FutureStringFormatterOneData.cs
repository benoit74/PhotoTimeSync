namespace PhotoTimeSync
{
    /// <summary>
    /// This class is used to represent a string that need computation based
    /// on a single argument
    /// </summary>
    public class FutureStringFormatterOneData : FutureStringFormatterBase
    {

        private string _value;
        private object _arg0;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">String with a single format token {0}</param>
        /// <param name="arg0">Format argument 0</param>
        public FutureStringFormatterOneData(string value, object arg0)
            : base()
        {
            _value = value;
            _arg0 = arg0;
        }

        protected override string Compute()
        {
            string res = string.Format(_value, _arg0);
            _value = null;
            _arg0 = null;
            return res; 
        }

    }
}


