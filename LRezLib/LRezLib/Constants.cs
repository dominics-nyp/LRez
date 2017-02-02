using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib
{
    public class Constants
    {
        public static readonly int ReservationStatus_PENDING = 0;
        public static readonly int ReservationStatus_APPROVED = 1;
        public static readonly int ReservationStatus_REJECTED = 2;

        public static readonly int MenuStatus_ACTIVE = 0;
        public static readonly int MenuStatus_HIDDEN = 1;
        public static readonly int MenuStatus_ARCHIVED = 2;

        public static readonly int MenuType_Regular = 0;
        public static readonly int MenuType_Celebrity = 1;
        public static readonly int MenuType_Themed = 2;
        public static readonly int MenuType_Degustation = 3;

        public static readonly string NEW = "NEW";

    }
}
