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
    public class InformationDAO
    {
        public enum InformationKey { AboutUsText = 1, AboutUsImage = 2, ContactUsText = 3, ContactUsMap = 4 };

        public static Information getInformation() 
        {
            Information info = new Information();

            string sql = "select * from Information";
            DataTable dt = DB.query(sql);

            foreach (DataRow dr in dt.Rows)
            {
                int key = (int)dr["ID"];
                switch (key)
                {
                    case (int)InformationKey.AboutUsText:
                        info.AboutUsText = dr["value"].ToString();
                        break;
                    case (int)InformationKey.AboutUsImage:
                        info.AboutUsImage = dr["value"].ToString();
                        break;
                    case (int)InformationKey.ContactUsText:
                        info.ContactUsText = dr["value"].ToString();
                        break;
                    case (int)InformationKey.ContactUsMap:
                        info.ContactUsMap = dr["value"].ToString();
                        break;
                    default:
                        Log.Warning("Information ID: " + key + " not recognized. Check DB.");
                        break;
                }
            }

            return info;
        }

        public static bool updateInformation(InformationKey key, string value)
        {
            string sql = "update Information set value=@value where ID=@id";
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@value", value));
            parameters.Add(new Parameter("@id", key));

            if (DB.execute(sql, parameters) > 0)
                return true;
            else
                return false;
        }
    }
}
