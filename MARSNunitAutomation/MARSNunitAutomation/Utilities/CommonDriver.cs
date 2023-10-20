using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.Utilities
{
    public class CommonDriver : ExtentReportHelper
    {
        public static IWebDriver driver;
       
        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentReportHelper.CreateExtentReport();

        }

      
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errorMessage);

            }
            else
            {
                test.Log(Status.Pass, "Test Pass");
            }

           
            string img = ExtentReportHelper.SaveScreenShot(driver, "Screenshot");
            test.Log(Status.Info, "Snapshot below: " + test.AddScreenCaptureFromPath(img));        

            driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }

}
