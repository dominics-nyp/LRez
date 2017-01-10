using LRezLib.DAO;
using LRezLib.Models;
using Microsoft.Security.Application;
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
            Information i = InformationDAO.getInformation();

            i.AboutUsText = Sanitizer.GetSafeHtmlFragment(i.AboutUsText);
            i.ContactUsText = Sanitizer.GetSafeHtmlFragment(i.ContactUsText);
            i.ContactUsMap = Sanitizer.GetSafeHtmlFragment(i.ContactUsMap);

            return i;
        }

        public static bool updateAboutText(string text)
        {
            string safe = Sanitizer.GetSafeHtmlFragment(text);
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, safe);
        }

        public static bool updateAboutImage(string url)
        {
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, url);
        }

        public static bool updateContactText(string text)
        {
            string safe = Sanitizer.GetSafeHtmlFragment(text);
            return InformationDAO.updateInformation(InformationDAO.InformationKey.ContactUsText, safe);
        }

        public static bool updateContactMap(string map)
        {
            string safe = Sanitizer.GetSafeHtmlFragment(map);
            return InformationDAO.updateInformation(InformationDAO.InformationKey.AboutUsImage, safe);
        }
    }
}
