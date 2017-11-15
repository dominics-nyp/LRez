using LRezLib.Connections;
using LRezLib.Exceptions;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.DAO
{
    public class CustomerProfileDAO
    {
        public static List<CustomerProfile> searchProfiles(string searchTerm)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql = "select distinct * from CustomerProfiles where contact like @contact or name like @name order by name";
            List<Parameter> parameters = new List<Parameter>() {
                new Parameter("@contact", "%" + searchTerm),
                new Parameter("@name", "%" + searchTerm + "%")
            };

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
                customerProfiles.Add(new CustomerProfile(dr));

            return customerProfiles;
        }

        public static List<CustomerProfile> searchProfiles(string name, string contact)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql = "select distinct * from CustomerProfiles where contact like @contact or name like @name order by name";
            List<Parameter> parameters = new List<Parameter>() {
                new Parameter("@contact", "%" + contact),
                new Parameter("@name", "%" + name + "%")
            };

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
                customerProfiles.Add(new CustomerProfile(dr));

            return customerProfiles;
        }

        public static List<CustomerProfile> searchProfilesByName(string name)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql = "select distinct * from CustomerProfiles where name like @name order by name";
            List<Parameter> parameters = new List<Parameter>() {
                new Parameter("@name", "%" + name + "%")
            };

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
                customerProfiles.Add(new CustomerProfile(dr));

            return customerProfiles;
        }

        public static List<CustomerProfile> searchProfilesByContact(string contact)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql = "select distinct * from CustomerProfiles where contact like @contact order by name";
            List<Parameter> parameters = new List<Parameter>() {
                new Parameter("@contact", "%" + contact),
            };

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
                customerProfiles.Add(new CustomerProfile(dr));

            return customerProfiles;
        }

        public static List<CustomerProfile> searchSuggestionsByContact(string contact)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql = 
                "select distinct R.name, R.contact, R.email from Reservations as R " +
                "where R.contact like @contact and R.contact not in (select contact from CustomerProfiles)";
            Parameter p = new Parameter("@contact", "%" + contact);

            DataTable dt = DB.query(sql, p);
            foreach (DataRow dr in dt.Rows)
            {
                CustomerProfile cp = new CustomerProfile();
                cp.Contact = (string)dr["contact"];
                cp.Name = (string)dr["name"];
                cp.Email = (string)dr["email"];
                customerProfiles.Add(cp);
            }

            return customerProfiles;
        }

        public static List<CustomerProfile> searchSuggestionsByName(string name)
        {
            List<CustomerProfile> customerProfiles = new List<CustomerProfile>();

            string sql =
                "select distinct R.name, R.contact, R.email from Reservations as R " +
                "where R.name like @name and R.contact not in (select contact from CustomerProfiles)";
            Parameter p = new Parameter("@name", "%" + name + "%");

            DataTable dt = DB.query(sql, p);
            foreach (DataRow dr in dt.Rows)
            {
                CustomerProfile cp = new CustomerProfile();
                cp.Contact = (string)dr["contact"];
                cp.Name = (string)dr["name"];
                cp.Email = (string)dr["email"];
                customerProfiles.Add(cp);
            }

            return customerProfiles;
        }

        public static CustomerProfile getProfile(string contact)
        {
            string sql = "select * from CustomerProfiles where contact=@contact";
            Parameter parameter = new Parameter("@contact", contact);

            DataTable dt = DB.query(sql, parameter);

            if (dt.Rows.Count > 0)
                return new CustomerProfile(dt.Rows[0]);
            else
                throw new Exception_NotFound("Exception: Profile for " + contact + " not found");
        }

        public static bool updateProfileName(string contact, string name)
        {
            string sql = "update CustomerProfiles set name=@name where contact=@contact";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@name", name),
                new Parameter("@contact", contact)
            };

            if (DB.execute(sql, parameters) < 0)
                return false;
            else
                return true;
        }

        public static bool updateProfileEmail(string contact, string email)
        {
            string sql = "update CustomerProfiles set email=@email where contact=@contact";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@email", email),
                new Parameter("@contact", contact)
            };

            if (DB.execute(sql, parameters) < 0)
                return false;
            else
                return true;
        }

        public static bool updateProfileDOB(string contact, int day, int month, int year)
        {
            string sql = "update CustomerProfiles set dob_day=@day, dob_month=@month, dob_year=@year where contact=@contact";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@day", day),
                new Parameter("@month", month),
                new Parameter("@year", year),
                new Parameter("@contact", contact)
            };

            if (DB.execute(sql, parameters) < 0)
                return false;
            else
                return true;
        }

        public static bool addCustomerEntry(string contact, string entry, int entryType, string createdBy, DateTime createdDate)
        {
            string sql = "insert into CustomerEntries (customer_contact, entry, type, created_date, created_by) values (@customer_contact, @entry, @type, @created_date, @created_by)";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@customer_contact", contact),
                new Parameter("@entry", entry),
                new Parameter("@type", entryType),
                new Parameter("@created_date", createdDate),
                new Parameter("@created_by", createdBy)
            };

            if (DB.execute(sql, parameters) < 0)
                return false;
            else
                return true;
        }

        public static bool deleteEntry(int id)
        {
            string sql = "delete from CustomerEntries where id=@id";
            Parameter p = new Parameter("@id", id);
            if (DB.execute(sql, p) < 0)
                return false;
            else
                return true;
        }

        public static bool createProfile(string contact, string name, string email)
        {
            string sql =
                "insert into CustomerProfiles (name, contact, email, dob_day, dob_month, dob_year) " +
                "values (@name, @contact, @email, @dob_day, @dob_month, @dob_year)";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@name", name),
                new Parameter("@contact", contact),
                new Parameter("@email", email),
                new Parameter("@dob_day", -1),
                new Parameter("@dob_month", -1),
                new Parameter("@dob_year", -1)
            };

            if (DB.execute(sql, parameters) <= 0)
                return false;
            else
                return true;
        }

    }
}
