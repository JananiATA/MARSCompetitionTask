using MARSNunitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.Pages
{
    public class LoginPage : CommonDriver
    {
        private IWebElement signInButton => webDriver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailMARS => webDriver.FindElement(By.Name("email"));
        private IWebElement passwordMARS => webDriver.FindElement(By.Name("password"));
        private IWebElement loginButton => webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        private IWebDriver webDriver;

        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
        }
        
        public void LoginActions(IWebDriver driver, String emailId, String password)

        {
            signInButton.Click();
            emailMARS.SendKeys(emailId);
            passwordMARS.SendKeys(password);
            loginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }
    }
}
