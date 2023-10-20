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
    public class Education_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;
        DataReader jsonFileObj;

        [Test, Order(1)]
        public void AddEducationTest()
        {
            test = null;
            test = extent.CreateTest("Add Education");
            test.Log(Status.Info, "Add Education");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string addEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddEducation.json";
            jsonFileObj = new DataReader(addEducationFilePath);
            List<AddEducation> list = new List<AddEducation>();
            list = jsonFileObj.ReadAddEducationFile();
           if (list != null)
            {
                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    string instituteName = profilePageObj.AssertEducation(driver);
                    string countryName = profilePageObj.AssertCountry(driver);
                    string title = profilePageObj.AssertTitle(driver);
                    string degree = profilePageObj.AssertDegree(driver);
                    string educationYear = profilePageObj.AssertEducationYear(driver);
                    Assert.That(instituteName == education.CollegeName, "Education not added successfully");
                    Assert.That(countryName == education.Country, "Country not added successfully");
                    Assert.That(title == education.Title, "Title not added successfully");
                    Assert.That(degree == education.Degree, "Degree not added successfully");
                    Assert.That(educationYear == education.Year, "Year not added successfully");

                }


            }

        }

        [Test, Order(2)]
        public void UpdateEducationTest()
        {
            test = null;
            test = extent.CreateTest("Update Education");
            test.Log(Status.Info, "Update Education");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string updateEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\UpdateEducation.json";
            jsonFileObj = new DataReader(updateEducationFilePath);
            List<UpdateEducation> list = new List<UpdateEducation>();
            list = jsonFileObj.ReadUpdateEducationFile();

            if (list != null)
            { 
                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    profilePageObj.UpdateEducation(driver, education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    string updatedInstituteName = profilePageObj.AssertEducation(driver);
                    string updatedCountry = profilePageObj.AssertCountry(driver);
                    string updatedTitle = profilePageObj.AssertTitle(driver);
                    string updatedDegree = profilePageObj.AssertDegree(driver);
                    string updatedYear = profilePageObj.AssertEducationYear(driver);
                    Assert.That(updatedInstituteName == education.CollegeNameNew, "Education not updated successfully");
                    Assert.That(updatedCountry == education.CountryNew, "Country not updated successfully");
                    Assert.That(updatedTitle == education.TitleNew, "Title not updated successfully");
                    Assert.That(updatedDegree == education.DegreeNew, "Degree not updated successfully");
                    Assert.That(updatedYear == education.YearNew, "Year not updated successfully");


                }
            }

        }

        [Test, Order(3)]

        public void DeleteEducationTest()
        {
            test = null;
            test = extent.CreateTest("Delete Education");
            test.Log(Status.Info, "Delete Education");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string deleteEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\DeleteEducation.json";
            jsonFileObj = new DataReader(deleteEducationFilePath);
            List<DeleteEducation> list = new List<DeleteEducation>();
            list = jsonFileObj.ReadDeleteEducationFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    profilePageObj.DeleteEducation();
                    string popUpMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(popUpMessage == education.PopUpMessage, "Education not Deleted");

                }

            }

        }

        [Test, Order(4)]
        public void AddEducationInvalidInputTest()
        {
            test = null;
            test = extent.CreateTest("Add Education with Invalid Input");
            test.Log(Status.Info, "Add Education with Invalid Input");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string addInvalidEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddEducationInvalidInput.json";
            jsonFileObj = new DataReader(addInvalidEducationFilePath);
            List<AddEducationInvalidInput> list = new List<AddEducationInvalidInput>();
            list = jsonFileObj.ReadEducationInvalidInputFile();

            if (list != null)
            {

                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    string popUpMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(popUpMessage == education.PopUpMessage, "Education Added with Invalid Input");

                }

            }

        }

        [Test, Order(5)]
        public void AddExistingEducationTest()
        {
            test = null;
            test = extent.CreateTest("Add Existing Education");
            test.Log(Status.Info, "Add Existing Education");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string addExistingEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddExistingEducation.json";
            jsonFileObj = new DataReader(addExistingEducationFilePath);
            List<AddExistingEducation> list = new List<AddExistingEducation>();
            list = jsonFileObj.ReadAddExistingEducationFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    profilePageObj.AddEducation(driver, education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    string popUpMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(popUpMessage == education.PopUpMessage, "Existing Education Added");

                }

            }

        }

        [Test, Order(6)]
        public void AddExistingEducationWithDifferentYearTest()
        {
            test = null;
            test = extent.CreateTest("Add Existing Education With Different Year");
            test.Log(Status.Info, "Add Existing Education With Different Year");
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
            profilePageObj.GoToEducationTab();
            profilePageObj.ResetEducationTable(driver);
            string addExistingEducationWithDifferentYearFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddExistingEducationWithDifferentYear.json";
            jsonFileObj = new DataReader(addExistingEducationWithDifferentYearFilePath);
            List<AddExistingEducationwWithDifferentYear> list = new List<AddExistingEducationwWithDifferentYear>();
            list = jsonFileObj.ReadAddExistingEducationWithDifferentYearFile();

            if (list != null)
            {

                foreach (var education in list)
                {
                    profilePageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    profilePageObj.AddEducation(driver, education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    string popUpMessage = profilePageObj.PopUpMessage(driver);
                    Assert.That(popUpMessage == education.PopUpMessage, "Existing Education Added");

                }


            }

        }

    }
}


    
