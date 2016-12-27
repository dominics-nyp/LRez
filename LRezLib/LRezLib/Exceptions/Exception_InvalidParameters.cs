using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Exceptions
{
    public class Exception_InvalidParameters : Exception
    {
        public Exception_InvalidParameters()
        {
        }

        public Exception_InvalidParameters(string message)
        : base(message)
        {
        }

        public Exception_InvalidParameters(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
