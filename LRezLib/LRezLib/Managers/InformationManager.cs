using LRezLib.DAO;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Managers
{
    public class InformationManager
    {
        public static Information getInformation()
        {
            return InformationDAO.getInformation();
        }

        public static bool updateAboutText(string text)
        {
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, text);
        }

        public static bool updateAboutImage(string url)
        {
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, url);
        }

        public static bool updateContactText(string text)
        {
            return InformationDAO.updateInformation(InformationDAO.InformationKey.ContactUsText, text);
        }

        public static bool updateContactMap(string map)
        {
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, map);
        }
    }
}
