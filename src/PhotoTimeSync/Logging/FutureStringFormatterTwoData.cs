namespace PhotoTimeSync
{
    /// <summary>
    /// This class is used to represent a string that need computation based
    /// on a two arguments
    /// </summary>
    public class FutureStringFormatterTwoData : FutureStringFormatterBase
    {

        private string _value;
        private object _arg0;
        private object _arg1;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">String with three format token {0} {1}</param>
        /// <param name="arg0">Format argument 0</param>
        /// <param name="arg1">Format argument 1</param>
        public FutureStringFormatterTwoData(string value, object arg0, object arg1)
            : base()
        {
            _value = value;
            _arg0 = arg0;
            _arg1 = arg1;
        }

        protected override string Compute()
        {
            string res = string.Format(_value, _arg0, _arg1);
            _value = null;
            _arg0 = null;
            _arg1 = null;
            return res; 
        }

    }
}
