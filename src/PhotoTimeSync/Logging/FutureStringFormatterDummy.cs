namespace PhotoTimeSync
{
    
    /// <summary>
    /// This class is used to represent a string that does not need computation.
    /// This is quite dummy but allows to have the same object type for all
    /// kinds of string (needing or not needing computation)
    /// </summary>
    public class FutureStringFormatterDummy : FutureStringFormatterBase
    {

        private string _value;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">String that does not need any formating</param>
        public FutureStringFormatterDummy(string value)
            : base()
        {
            _value = value;
        }

        protected override string Compute()
        {
            string res = _value;
            _value = null;
            return res;
        }

    }
}
