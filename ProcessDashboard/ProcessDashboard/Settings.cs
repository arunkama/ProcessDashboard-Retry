﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessDashboard
{
    class Settings
    {
        private static Settings _instance;

        private string _baseurl;

        public string Dataset {
            get { return "mock"; }
        }

        public string DateTimePattern
        {
            get { return "yyyy-MM-dd\'T\'HH:mm:ssZ"; }
             }
        public string AuthHeader
        {
            get
            {
                var authData = string.Format("{0}:{1}", "test", "test");
                return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            }
        }

        private Settings()
        {

        }



        public static Settings GetInstance()
        {
            return _instance ?? (_instance = new Settings());
        }


    }
}
