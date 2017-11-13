using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Models
{
    public class CustomerProfile
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int DOB_Day { get; set; }
        public int DOB_Month { get; set; }
        public int DOB_Year { get; set; }

        public CustomerProfile()
        {
            this.Name = "";
            this.Contact = "";
            this.Email = "";
            this.DOB_Day = -1;
            this.DOB_Month = -1;
            this.DOB_Year = -1;
        }

        public CustomerProfile(DataRow dr)
        {
            if (dr["name"] != DBNull.Value)
                this.Name = (string)dr["name"];
            if (dr["contact"] != DBNull.Value)
                this.Contact = (string)dr["contact"];
            if (dr["email"] != DBNull.Value)
                this.Email = (string)dr["email"];
            if (dr["dob_day"] != DBNull.Value)
                this.DOB_Day = (int)dr["dob_day"];
            if (dr["dob_month"] != DBNull.Value)
                this.DOB_Month = (int)dr["dob_month"];
            if (dr["dob_year"] != DBNull.Value)
                this.DOB_Year = (int)dr["dob_year"];
        }
    }
}
