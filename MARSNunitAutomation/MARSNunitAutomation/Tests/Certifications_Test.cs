using AventStack.ExtentReports;
using MARSNunitAutomation.JasonObjectClasses;
using MARSNunitAutomation.Pages;
using MARSNunitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.Tests
{
    [TestFixture]
    public class Certifications_Test : CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;
        DataReader jsonFileObj;

        [Test, Order(1)]
        public void AddCertificationTest()

        {
            test = null;
            test = extent.CreateTest("Add Certification");
            test.Log(Status.Info, "Add Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string addCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddCertifications.json";
            jsonFileObj = new DataReader(addCertificationFilePath);
            List<AddCertifications> list = new List<AddCertifications>();
            list = jsonFileObj.ReadCertificationFile();

            if (list != null)
            {

                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    string addedname = profilePageObj.AssertCertification(driver);
                    string institutionName = profilePageObj.AssertCertifiedFrom(driver);
                    string certifiedYear = profilePageObj.AssertCertifiedYear(driver);
                    Assert.That(addedname == certification.CertificationName, "Certification not added successfully");
                    Assert.That(institutionName == certification.CertifiedFrom, "Institution name not added Successfully");
                    Assert.That(certifiedYear == certification.Year, "Certified Year not added Successfully");

                }
            }

        }

        [Test, Order(2)]
        public void UpdateCertificationTest()


        {
            test = null;
            test = extent.CreateTest("Update Certification");
            test.Log(Status.Info, "Update Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }

            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string updateCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\UpdateCertification.json";
            jsonFileObj = new DataReader(updateCertificationFilePath);
            List<UpdateCertification> list = new List<UpdateCertification>();
            list = jsonFileObj.ReadUpdareCertificationFile();
            if (list != null)
            {

                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    profilePageObj.UpdateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string updatedname = profilePageObj.AssertCertification(driver);
                    string updatedCertifiedFrom = profilePageObj.AssertCertifiedFrom(driver);
                    string updatedYear = profilePageObj.AssertCertifiedYear(driver);
                    Assert.That(updatedname == certification.CertificationNameNew, "Certification not updated successfully");
                    Assert.That(updatedCertifiedFrom == certification.CertifiedFromNew, "Certified From not updated successfully");
                    Assert.That(updatedYear == certification.YearNew, "Year not updated successfully");

                }

            }

        }

        [Test, Order(3)]
        public void DeleteCertificationTest()

        {
            test = null;
            test = extent.CreateTest("Delete Certification");
            test.Log(Status.Info, "Delete Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string filepath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\DeleteCertification.json";
            jsonFileObj = new DataReader(filepath);
            List<DeleteCertification> list = new List<DeleteCertification>();
            list = jsonFileObj.ReadDeleteCertificationFile();

            if (list != null)
            {
                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    profilePageObj.DeleteCertification(driver);
                    string expectedMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification not Deleted");

                }

            }

        }

        [Test, Order(4)]
        public void AddCertificationInvalidInputTest()

        {
            test = null;
            test = extent.CreateTest("Add Certification with Invalid Input");
            test.Log(Status.Info, "Add Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string addInvalidCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddCertificationInvalidInput.json";
            jsonFileObj = new DataReader(addInvalidCertificationFilePath);
            List<AddCertificationInvalidInput> list = new List<AddCertificationInvalidInput>();
            list = jsonFileObj.ReadCertificationInvalidInputFile();
            if (list != null)
            {

                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    string expectedMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Invalid Data");

                }

            }

        }

        [Test, Order(5)]
        public void AddExistingCertificationTest()

        {
            test = null;
            test = extent.CreateTest("Add Existing Certification");
            test.Log(Status.Info, "Add Existing Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string addExistingCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddExistingCertification.json";
            jsonFileObj = new DataReader(addExistingCertificationFilePath);
            List<AddExistingCertification> list = new List<AddExistingCertification>();
            list = jsonFileObj.ReadExistingCertificationFile();
            if (list != null)
            {
                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    profilePageObj.CreateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string expectedMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Duplicate Data");

                }

            }

        }

        [Test, Order(6)]
        public void AddExistingCertificationWithDifferentYearTest()

        {
            test = null;
            test = extent.CreateTest("Add Existing Certification With Different Year");
            test.Log(Status.Info, "Add Existing Certification With Different Year");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new DataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GoToCertificationsTab();
            profilePageObj.ResetCertificationTable(driver);
            string addExistingCertificationWithDifferentYearFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddExistingCertificationWithDifferentYear.json";
            jsonFileObj = new DataReader(addExistingCertificationWithDifferentYearFilePath);
            List<AddExistingCertificationWithDifferentYear> list = new List<AddExistingCertificationWithDifferentYear>();
            list = jsonFileObj.ReadExistingCertificationWithDifferentYearFile();
            if (list != null)
            {
                foreach (var certification in list)
                {
                    profilePageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    profilePageObj.CreateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string expectedMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Duplicate Data");

                }

            }

        }

       
    }
}
            
        

    

