namespace PhotoTimeSync
{
    /// <summary>
    /// This class is used to represent a string that need computation based
    /// on a three arguments
    /// </summary>
    public class FutureStringFormatterThreeData : FutureStringFormatterBase
    {

        private string _value;
        private object _arg0;
        private object _arg1;
        private object _arg2;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">String with three format token {0} {1} {2}</param>
        /// <param name="arg0">Format argument 0</param>
        /// <param name="arg1">Format argument 1</param>
        /// <param name="arg2">Format argument 2</param>
        public FutureStringFormatterThreeData(string value, object arg0, object arg1, object arg2) : base()
        {
            _value = value;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;
        }

        protected override string Compute()
        {
            string res = string.Format(_value, _arg0, _arg1, _arg2);
            _value = null;
            _arg0 = null;
            _arg1 = null;
            _arg2 = null;
            return res; 
        }

    }
}
