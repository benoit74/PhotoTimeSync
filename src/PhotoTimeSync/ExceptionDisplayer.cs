using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoTimeSync
{
    public class ExceptionDisplayer
    {

        private Exception _ex;

        public ExceptionDisplayer(Exception ex)
        {
            _ex = ex;
        }

        public override string ToString()
        {
            return ToString(true);
        }

        public string ToString(bool displayStackTrace)
        {
            StringBuilder sb = new StringBuilder();
            Exception curException = _ex;
            do
            {
                if (!string.IsNullOrEmpty(curException.Message))
                    sb.AppendLine(curException.Message);
                if (displayStackTrace && !string.IsNullOrEmpty(curException.StackTrace))
                    sb.AppendLine(curException.StackTrace);
                curException = curException.InnerException;
            } while (curException != null);
            return sb.ToString();
        }


        public static string GetString(Exception ex)
        {
            ExceptionDisplayer exd = new ExceptionDisplayer(ex);
            return exd.ToString();
        }

    }
}
