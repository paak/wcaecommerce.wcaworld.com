using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ecom
{
    public static class AppSetting
    {
        public static bool GetIsLive
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsLive"]);
            }
        }
    }
}