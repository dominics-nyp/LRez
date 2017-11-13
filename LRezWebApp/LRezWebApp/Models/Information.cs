using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRezWebApp.Models
{
    public class Information
    {
        public string AboutUsText { get; set; }

        public string AboutUsImage { get; set; }

        public string ContactUsText { get; set; }

        public string ContactUsMap { get; set; }

        public Information(string json)
        {
            JObject jObject = JObject.Parse(json);
            AboutUsText = (string)jObject["AboutUsText"];
            AboutUsImage = (string)jObject["AboutUsImage"];
            ContactUsText = (string)jObject["ContactUsText"];
            ContactUsMap = (string)jObject["ContactUsMap"];
        }

    }
}