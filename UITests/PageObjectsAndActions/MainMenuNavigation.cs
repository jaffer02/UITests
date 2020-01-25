using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.Scripts.Utilities;

namespace UITests.PageObjectsAndActions
{
    public class MainMenuNavigation
    {
        public enum AutomationTools_Navigation
        {
            [Description("Selenium")]
            Selenium,
            [Description("BDD")]
            BDD
        };

        public enum Selenium_Navigation
        {
            [Description("Selenium WebDriver")]
            SeleniumWebDriver,
            [Description("Selenium RC")]
            SeleniumRC,
            [Description("Selenium IDE")]
            SeleniumIDE
        };

        public enum BDD_Navigation
        {
            [Description("Specflow")]
            Specflow,
            [Description("Cucumber")]
            Cucumber
        };

        private static void clickMenuItem(String menuItem)
        {
            BrowserOperations.waitTillBrowserLoads();
            IWebElement menu = Globalclass.driver.FindElement(By.XPath(""));
            menu.FindElement(By.LinkText(menuItem)).Click();
            BrowserOperations.waitTillBrowserLoads();
            Thread.Sleep(1000);
        }

        private static IWebElement getMenu(String nameOfMenu)
        {
            BrowserOperations.waitTillBrowserLoads();
            IList<IWebElement> menus = Globalclass.driver.FindElements(By.ClassName("ClassName"));
            foreach(IWebElement menu in menus)
            {
                if (menu.Text.Equals(nameOfMenu))
                {
                    return menu;
                }
            }
            return null;
        }

        public static void SelectAutomationTools_Function(AutomationTools_Navigation function)
        {
            getMenu("Automation Tools").Click();
            clickMenuItem(CommonOperations.GetEnumDescription(function));
        }

        public static void SelectDragAndDrop_Function()
        {
            getMenu("Drag and Drop").Click();
        }
    }
}
