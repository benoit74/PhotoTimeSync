
namespace PhotoTimeSync
{
    /// <summary>
    /// This class is used to represent a string that need computation based
    /// on a many arguments
    /// </summary>
    public class FutureStringFormatterArrayData : FutureStringFormatterBase
    {

        private string _value;
        private object[] _args;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">String with format token(s) {x}</param>
        /// <param name="args">Format arguments</param>
        public FutureStringFormatterArrayData(string value, params object[] args)
            : base()
        {
            _value = value;
            _args = args;
        }

        protected override string Compute()
        {
            string res = string.Format(_value, _args);
            _value = null;
            _args = null;
            return res;
        }

    }
}


