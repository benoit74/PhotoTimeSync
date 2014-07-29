using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    /// <summary>
    /// Annotator interface (empty) used to indicate objects that 
    /// represents a string that can be computed at its first use.
    /// Those classes are used to avoid the string computation if
    /// not needed but this is not known before-hand.
    /// </summary>
    public interface IFutureStringFormatter
    {
    }
}
