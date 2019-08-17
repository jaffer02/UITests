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
        public enum Assets_Navigation
        {
            [Description("Asset Search")]
            AssetSearch,
            [Description("Advanced Asset Search")]
            AdvancedAssetSearch
        };

        public enum Reports_Navigation
        {
            [Description("Asset Report")]
            AssetReport,
            [Description("Advanced Asset Report")]
            AdvancedAssetReport
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

        public static void SelectAssets_Function(Assets_Navigation function)
        {
            getMenu("Assets").Click();
            clickMenuItem(CommonOperations.GetEnumDescription(function));
        }
    }
}
