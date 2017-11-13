using LRezLib.Connections;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.DAO
{
    public class CustomerEntryDAO
    {
        public static List<CustomerEntry> getCustomerEntries(string contact, int type, int maxRecords=-1)
        {
            List<CustomerEntry> customerEntries = new List<CustomerEntry>();

            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@contact", contact),
                new Parameter("@type", type)
            };

            string sql = "select ";
            if (maxRecords > 0)
            {
                sql += "top (@maxRecords) ";
                parameters.Add(new Parameter("@maxRecords", maxRecords));
            }

            sql += "* from CustomerEntries where customer_contact=@contact and type=@type order by created_date";
            if (type == Constants.CustomerEntryType_Interaction)
                sql += " desc";
            

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
            {
                customerEntries.Add(new CustomerEntry(dr));
            }

            return customerEntries;
        }

    }
}
