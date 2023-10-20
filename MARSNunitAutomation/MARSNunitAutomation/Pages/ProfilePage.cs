using MARSNunitAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.Pages
{
    public class ProfilePage : CommonDriver
    {

        public static IWebDriver webDriver;
        public ProfilePage(IWebDriver driver)
        {
            webDriver = driver;

        }
        private IWebElement educationTab => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private IWebElement certificationsTab => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        
        public void GoToEducationTab()
        {
            educationTab.Click();
        }

        public void GoToCertificationsTab()
        {
            certificationsTab.Click();
        }
      
        //Add New Certification
        private IWebElement addNewButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));                                                                     
        private IWebElement certificationTextBox => webDriver.FindElement(By.Name("certificationName"));
        private IWebElement certifiedFromTextBox => webDriver.FindElement(By.Name("certificationFrom"));      
        private IWebElement selectYear => webDriver.FindElement(By.Name("certificationYear"));
        private IWebElement addButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        public void CreateCertification(IWebDriver driver, string certification, string certifiedFrom, string year)
        {
            addNewButton.Click();
            certificationTextBox.SendKeys(certification);
            certifiedFromTextBox.SendKeys(certifiedFrom);
            SelectElement certificationYear = new SelectElement(selectYear);
            certificationYear.SelectByValue(year);
            addButton.Click();
            Thread.Sleep(1000);

        }
       
        //Assert Certification
        private IWebElement certificationname => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));

        public string AssertCertification(IWebDriver driver)
        {
            return certificationname.Text;
        }

        //Assert CertifiedFrom

        private IWebElement certifiedFrom => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
        
        public string AssertCertifiedFrom(IWebDriver driver)
        {
            return certifiedFrom.Text;
        }

        //Assert CertificationYear

        private IWebElement certifiedYear => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));

        public string AssertCertifiedYear(IWebDriver driver)
        {
            return certifiedYear.Text;
        }

        //Reset Certification Table
        public void ResetCertificationTable(IWebDriver driver)
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr")).Count;
                                                         
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i")).Click();
                                                
                    Thread.Sleep(1000);
                }
            }


        }

        //Update Certification

        private IWebElement editIcon => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private IWebElement editCertificationTextBox => webDriver.FindElement(By.Name("certificationName"));
        private IWebElement editCertifiedFromTextBox => webDriver.FindElement(By.Name("certificationFrom"));
        private IWebElement editYear => webDriver.FindElement(By.Name("certificationYear"));
        private IWebElement updateButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));

        public void UpdateCertification(IWebDriver driver, string certificationName, string certifiedFrom, string year)
        {
            editIcon.Click();
            editCertificationTextBox.Clear();
            editCertificationTextBox.SendKeys(certificationName);
            editCertifiedFromTextBox.Clear();
            editCertifiedFromTextBox.SendKeys(certifiedFrom);
            SelectElement certificationYear = new SelectElement(editYear);
            certificationYear.SelectByValue(year);
             updateButton.Click();
             Thread.Sleep(1000);

        }

        //Delete Certification

        private IWebElement deleteIcon => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
        public void DeleteCertification(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i", 5);
            deleteIcon.Click();
            Thread.Sleep(1000);
        }

        private IWebElement popUpMessage => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public string PopUpMessage(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return popUpMessage.Text;
        }

        //Resetting Education Table

        public void ResetEducationTable(IWebDriver driver)
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr")).Count;
                                                
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i")).Click();
                                                  
                    Thread.Sleep(1000);
                }
            }


        }

        //Add Education
        private IWebElement addNewEducationButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement collegeTextBox => webDriver.FindElement(By.Name("instituteName"));
        private IWebElement selectCountry => webDriver.FindElement(By.Name("country"));
        private IWebElement selectTitle => webDriver.FindElement(By.Name("title"));
        private IWebElement degreeTextBox => webDriver.FindElement(By.Name("degree"));
        private IWebElement selectYearOfGraduation => webDriver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement addEducationButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));

        public void AddEducation(IWebDriver driver, string collegeName, string countryName, string titleName,string degree,string year)
        {
            addNewEducationButton.Click();
            collegeTextBox.SendKeys(collegeName);
            SelectElement country = new SelectElement(selectCountry);
            country.SelectByValue(countryName);
            SelectElement title = new SelectElement(selectTitle);
            title.SelectByValue(titleName);
            degreeTextBox.SendKeys(degree);
            SelectElement graduationYear = new SelectElement(selectYearOfGraduation);
            graduationYear.SelectByValue(year);
            addEducationButton.Click();
            Thread.Sleep(1000);
        }

        //Assert Education
        private IWebElement institutename => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
                                                                          
        public string AssertEducation(IWebDriver driver)
        {
            return institutename.Text;
        }

        //Assert country

        private IWebElement country => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

        public string AssertCountry(IWebDriver driver)
        {
            return country.Text;
        }

        //Assert Title
        private IWebElement title => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));

        public string AssertTitle(IWebDriver driver)
        {
            return title.Text;
        }

        //Assert Degree
        private IWebElement degree => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));

        public string AssertDegree(IWebDriver driver)
        {
            return degree.Text;
        }

        //Assert EducationYear
        private IWebElement educationYear => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));

        public string AssertEducationYear(IWebDriver driver)
        {
            return educationYear.Text;
        }
       
        //Update Education

        private IWebElement editButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        private IWebElement editCollegeName => webDriver.FindElement(By.Name("instituteName"));
        private IWebElement editCountry => webDriver.FindElement(By.Name("country"));
        private IWebElement editTitle => webDriver.FindElement(By.Name("title"));
        private IWebElement editDegree => webDriver.FindElement(By.Name("degree"));
        private IWebElement editYearOfGraduation => webDriver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement updateEducationButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));

        public void UpdateEducation(IWebDriver driver, string collegeName, string countryName, string newtitle, string degree, string yearOfGraduation)
        {
            editButton.Click();
            editCollegeName.Clear();
            editCollegeName.SendKeys(collegeName);
            SelectElement country = new SelectElement(editCountry);
            country.SelectByValue(countryName);
            SelectElement title = new SelectElement(editTitle);
            title.SelectByValue(newtitle);
            editDegree.Clear();
            editDegree.SendKeys(degree);
            SelectElement year = new SelectElement(editYearOfGraduation);
            year.SelectByValue(yearOfGraduation);
            updateEducationButton.Click();
            Thread.Sleep(1000);
        }

        // Delete Education
        private IWebElement deleteEducationIcon => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));

        public void DeleteEducation()
        {
            deleteEducationIcon.Click();
            Thread.Sleep(1000);
        }


    }
}
