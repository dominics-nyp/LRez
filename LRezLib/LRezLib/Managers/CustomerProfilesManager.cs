using LRezLib.DAO;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Managers
{
    public class CustomerProfilesManager
    {
        public static List<CustomerProfile> searchCustomerProfiles(string searchTerm)
        {
            return CustomerProfileDAO.searchProfiles(searchTerm);
        }

        public static List<CustomerProfile> searchCustomerProfiles(string name, string contact)
        {
            return CustomerProfileDAO.searchProfiles(name, contact);
        }

        public static List<CustomerProfile> searchCustomerProfilesByName(string name)
        {
            return CustomerProfileDAO.searchProfilesByName(name);
        }

        public static List<CustomerProfile> searchCustomerProfilesByContact(string contact)
        {
            return CustomerProfileDAO.searchProfilesByContact(contact);
        }

        public static List<CustomerProfile> searchSuggestionsByContact(string contact)
        {
            return CustomerProfileDAO.searchSuggestionsByContact(contact);
        }

        public static List<CustomerProfile> searchSuggestionsByName(string name)
        {
            return CustomerProfileDAO.searchSuggestionsByName(name);
        }

        public static CustomerProfile getCustomerProfile(string contact)
        {
            return CustomerProfileDAO.getProfile(contact);
        }

        public static List<CustomerEntry> getCustomerEntries(string contact, int type, int maxRecords=-1)
        {
            return CustomerEntryDAO.getCustomerEntries(contact, type, maxRecords);
        }

        public static bool updateProfileName(string contact, string name)
        {
            return CustomerProfileDAO.updateProfileName(contact, name);
        }

        public static bool updateProfileEmail(string contact, string email)
        {
            return CustomerProfileDAO.updateProfileEmail(contact, email);
        }

        public static bool updateProfileDOB(string contact, int day, int month, int year)
        {
            return CustomerProfileDAO.updateProfileDOB(contact, day, month, year);
        }

        public static bool addCustomerEntry(string contact, string entry, int entryType, string createdBy, DateTime createdDate)
        {
            return CustomerProfileDAO.addCustomerEntry(contact, entry, entryType, createdBy, createdDate);
        }

        public static bool deleteEntry(int id)
        {
            return CustomerProfileDAO.deleteEntry(id);
        }

        public static bool createProfile(string contact, string name, string email)
        {
            return CustomerProfileDAO.createProfile(contact, name, email);
        }

    }
}
