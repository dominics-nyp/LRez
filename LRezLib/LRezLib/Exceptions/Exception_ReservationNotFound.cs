using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Exceptions
{
    public class Exception_ReservationNotFound : Exception
    {
        public Exception_ReservationNotFound()
        {
        }

        public Exception_ReservationNotFound(string message)
        : base(message)
        {
        }

        public Exception_ReservationNotFound(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
