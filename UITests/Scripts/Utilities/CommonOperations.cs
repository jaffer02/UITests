using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.PageObjectsAndActions;

namespace UITests.Scripts.Utilities
{
    class CommonOperations
    {
        private static readonly object ThreadS;

        public static  String getUserIDUpperCase()
        {
            String ret = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String[] userid = ret.Split('\\');
            return (userid[1].ToUpper());
        }

        public static void clearDirectory(String path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            foreach(FileInfo file in d.GetFiles())
            {
                file.Delete();
            }
        }

        private static Boolean checkFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                //Log.info(file.Name + "File downloaded completely....");

            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static void waitTillFilesGetSaved(string folderpath)
        {
            //Log.info("Waiting for the file to be saved/downloaded");
            int iteration = 500;
            DirectoryInfo d = new DirectoryInfo(folderpath);
            do
            {
                Thread.Sleep(1000);
                FileInfo[] filesinFolder = d.GetFiles();
                Globalclass.FIleName = filesinFolder[0].Name;
                if (filesinFolder.Length > 0)
                {
                    FileInfo fInfo = new FileInfo(filesinFolder[0].FullName);
                    if (checkFileLocked(fInfo))
                    {
                        //Log.info("Waiting for the file to be saved/downloaded");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        //Log.Info("Files saved/downloaded");
                        return;
                    }
                }
                iteration--;
            } while (iteration > 0);
        }

        public static string GetEnumDescription(object enumvalue)
        {
            FieldInfo f = enumvalue.GetType().GetField(enumvalue.ToString());
            if (null != f)
            {
                object[] attrs = f.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                if(attrs!=null && attrs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
                }
            }
            return null;
        }

        public static String getdateNow(String format)
        {
            var date = DateTime.Now;
            return (date.ToString(format));
        }

        public static String getTimeStamp()
        {
            var date = DateTime.Now;
            return (date.Day + "" + date.Month + "" + date.Year + "" + date.Hour + "" + date.Minute + "" + date.Second);
        }

        public static String getday()
        {
            var date = DateTime.Now;
            return (date.Day + "" + date.Month + "" + date.Year).ToString();
        }

        public static String getnormalizedLocation(string appConfigString)
        {
            var projectlocation = Environment.CurrentDirectory;
            var folder = ConfigurationManager.AppSettings[appConfigString];
            var location = projectlocation.Replace(@"\bin\Debug","");
            return (Path.Combine(location, folder));
        }

        public static void TestFixturesetup()
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            //Globalclass.sqlinputFolder = getnormalizedLocation("sqlinputFolder");
            var downloadFolder = ConfigurationManager.AppSettings["browserDownloadfolder"];

            clearDirectory(downloadFolder);

            //TestStartup.getUserPwdAndEnv();
            DBOperation.setDBConnection();
            var folderForScreenshot = Path.Combine(resultlocation, getday());
            Console.WriteLine("folderForScreenshot : " + folderForScreenshot);
            Directory.CreateDirectory(folderForScreenshot);
            Console.WriteLine("folderForScreenshot : " + folderForScreenshot);
            //Log.Info("folderForScreenshot : " + folderForScreenshot);
            LoginPage.login();
        }

        public static void TestFixtureteardown()
        {
            Globalclass.dbconnection.Close();
            if (Globalclass.driver != null)
            {
                Globalclass.driver.Quit();
            }
        }

        public static void TestTeardown()
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            if (TestContext.CurrentContext.Result.Outcome.ToString().Equals("Failed"))
            {
                Screenshot ss = ((ITakesScreenshot)Globalclass.driver).GetScreenshot();
                var saveScreenshotInToFolder = Globalclass.resultlocation + ".jpeg";
                ss.SaveAsFile(saveScreenshotInToFolder, ScreenshotImageFormat.Jpeg);
                //ReportResultUtility.EndReportResultString();
                //ReportResultUtility.WriteToHtmlFile(ReportResultUtility.reportResultHtmlString.ToString(), Globalclass.resultlocation + ".html");
                Globalclass.driver.Quit();
                Globalclass.driver = null;
            }
        }

        public static void testsetup()
        {
            if (Globalclass.driver == null)
            {
                //Log.Info("Launching application again!!!");
                LoginPage.login();
            }
        }

        public static void TestFixtureteardown1()
        {
            Globalclass.dbconnection.Close();
            if (Globalclass.driver != null)
            {
                //ReportResultUtility.EndReportResultString();
                //ReportResultUtility.WriteToHtmlFile(ReportResultUtility.reportResultHtmlString.ToString(), Globalclass.resultlocation + ".html");
                Globalclass.driver.Quit();
            }
        }

        public static void CreateReportForTestMethod(String testMethod)
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            var folderForScreenshot = Path.Combine(resultlocation, getday());
            folderForScreenshot = Path.Combine(folderForScreenshot, testMethod);
            Directory.CreateDirectory(folderForScreenshot);
            Globalclass.resultlocation = Path.Combine(folderForScreenshot, testMethod);
        }
    }
}
