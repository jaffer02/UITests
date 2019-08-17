using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Scripts.Utilities
{
    public static class ReportResultUtility
    {
        public static StringBuilder reportResultHtmlString;

        public static void InitializeReportString(String TestSuiteName)
        {
            CommonOperations.CreateReportForTestMethod(TestSuiteName);
            reportResultHtmlString = new StringBuilder();
            reportResultHtmlString.Append("<html><header><title>").Append(TestSuiteName).Append("</title></header><body><table border=\"1\">");
            reportResultHtmlString.Append("<tr style=\"background-color:#99CCFF\"><td><b> Test Case </b></td><td><b> Test Result </b></td></tr>");
        }

        public static void AddTestPassToReportResultString(String TestMethod, String TestResult)
        {
            reportResultHtmlString.Append("<tr style=\"background-color:#33CC33\"><td>").Append(TestMethod).Append("</td><td>").Append(TestResult).Append("</td></tr>");
        }

        public static void AddTestFailToReportResultString(String TestMethod, String TestResult)
        {
            reportResultHtmlString.Append("<tr style=\"background-color:#FFFF00\"><td>").Append(TestMethod).Append("</td><td>").Append(TestResult).Append("</td></tr>");
        }

        public static void EndReportResultString()
        {
            reportResultHtmlString.Append("</table></body></html>");
        }

        public static void WriteToHtmlFile(String content, String filename)
        {
            //Create a file stream
            FileStream file = new FileStream(filename, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);

            //Write to the file
            sw.WriteLine(content);
            sw.Close();
        }

        public static void CreateReport(String content, String filename)
        {
            ReportResultUtility.EndReportResultString();
            ReportResultUtility.WriteToHtmlFile(content, filename);
        }
    }
}
