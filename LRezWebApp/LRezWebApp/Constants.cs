using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRezWebApp
{
    public class Constants
    {
        public const int ReservationStatus_PENDING = 0;
        public const int ReservationStatus_APPROVED = 1;
        public const int ReservationStatus_REJECTED = 2;
        public const int ReservationStatus_CANCELLED = 3;
        public static readonly Dictionary<int, string> HashReservationStatus = new Dictionary<int, string>() {
            { ReservationStatus_PENDING, "Pending" },
            { ReservationStatus_APPROVED, "Confirmed" },
            { ReservationStatus_REJECTED, "Rejected" },
            { ReservationStatus_CANCELLED, "Cancelled" }
        };

        public const int MenuStatus_ACTIVE = 0;
        public const int MenuStatus_HIDDEN = 1;
        public const int MenuStatus_ARCHIVED = 2;

        public const int MenuType_Regular = 0;
        public const int MenuType_Celebrity = 1;
        public const int MenuType_Themed = 2;
        public const int MenuType_Degustation = 3;

        public const int CustomerEntryType_Interaction = 0;
        public const int CustomerEntryType_Note = 1;

        public const string NEW = "NEW";
    }
}