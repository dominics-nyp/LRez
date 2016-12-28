using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Exceptions
{
    public class Exception_NotFound : Exception
    {
        public Exception_NotFound()
        {
        }

        public Exception_NotFound(string message)
        : base(message)
        {
        }

        public Exception_NotFound(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
