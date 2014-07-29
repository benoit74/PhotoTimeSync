
namespace PhotoTimeSync
{

    /// <summary>
    /// This class is used as a base to store string computed value
    /// at first usage and then simply returning the computed value
    /// at later calls to 'toString'.
    /// </summary>
    public abstract class FutureStringFormatterBase : IFutureStringFormatter
    {

        private string _computedValue;
        private bool _isComputed;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FutureStringFormatterBase()
        {
            _isComputed = false;
        }

        /// <summary>
        /// Function that compute the string at first call
        /// </summary>
        /// <returns>The string computed</returns>
        protected abstract string Compute();

        /// <summary>
        /// Computes the string if first call, otherwise returns the
        /// previously computed value.
        /// </summary>
        /// <returns>The string in this formatter</returns>
        public override string ToString()
        {
            if (!_isComputed)
            {
                _computedValue = Compute();
                _isComputed = true;
            }
            return _computedValue;
        }

    }
}


