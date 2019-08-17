using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Scripts.Utilities
{
    class Globalclass
    {
        public static IWebDriver driver;
        public static String FIleName;
        public static SqlConnection dbconnection;
        public static String resultlocation;

        public static String envToTest;
        public static String ssoUserName;
        public static String ssoPassword;

        public static String dbEnv;
    }
}
