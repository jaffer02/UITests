using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Scripts.Utilities;

namespace UITests.PageObjectsAndActions
{
    class LoginPage
    {
        private static IWebElement userName_TextObject;
        private static IWebElement password_TextObject;
        private static IWebElement login_ButtonObject;

        public static Boolean login()
        {
            try
            {
                var url = ConfigurationManager.AppSettings[Globalclass.envToTest];
                BrowserOperations.LoadDriver(url);

                userName_TextObject = Globalclass.driver.FindElement(By.Id("username"));
                userName_TextObject.Click();
                userName_TextObject.SendKeys(Globalclass.ssoUserName);

                password_TextObject = Globalclass.driver.FindElement(By.Id("password"));
                password_TextObject.Click();
                password_TextObject.SendKeys(Globalclass.ssoPassword);

                login_ButtonObject = Globalclass.driver.FindElement(By.Id("login"));
                login_ButtonObject.Click();

                BrowserOperations.waitTillBrowserLoads();
                return true;
            }
            catch(Exception e)
            {
                //Log.Info(e.Message);
                return false;
            }
        }
    }
}
