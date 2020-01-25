using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.Scripts.Utilities;

namespace UITests.PageObjectsAndActions
{
    class BrowserOperations
    {
        public static IWebDriver LoadDriver(String URL)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            var driver = new ChromeDriver(options);

            //IWebDriver driver1 = new ChromeDriver();

            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            Globalclass.driver = driver;
            return Globalclass.driver;
        }

        public static void waitTillBrowserLoads()
        {
            Thread.Sleep(200);
            int i = 300;
            do
            {
                IWebElement body = Globalclass.driver.FindElement(By.TagName("body"));
                if (body.Enabled)
                {
                    return;
                }
                Thread.Sleep(250);
                i--;
            } while (i != 0);
        }
    }
}
