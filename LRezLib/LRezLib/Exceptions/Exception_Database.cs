using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Exceptions
{
    class Exception_Database : Exception
    {
        public Exception_Database()
        {
        }

        public Exception_Database(string message)
        : base(message)
        {
        }

        public Exception_Database(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
