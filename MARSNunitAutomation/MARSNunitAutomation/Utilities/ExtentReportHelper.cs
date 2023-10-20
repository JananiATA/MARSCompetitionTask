

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;

namespace MARSNunitAutomation.Utilities

{
    public class ExtentReportHelper
    {

        public static ExtentTest test;
        public static ExtentReports extent;
     

        public static string SaveScreenShot(IWebDriver driver, string screenShotFileName)
        {
          
            string screenshotPath = ProjectPathHelper.projectPath + "TestReports\\";
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(screenshotPath);
            fileName.Append(screenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            fileName.Append(".jpeg");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
            return fileName.ToString();

        }

        public static void CreateExtentReport()
        {
            extent = new ExtentReports();

            string reportPath = ProjectPathHelper.projectPath + "TestReports\\TestReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.LoadConfig(ProjectPathHelper.projectPath + "extent_config.xml");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Test");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "Tester");
            htmlReporter.LoadConfig(ProjectPathHelper.projectPath + "extent_config.xml");

        }

    }
    
    



}



    


    
