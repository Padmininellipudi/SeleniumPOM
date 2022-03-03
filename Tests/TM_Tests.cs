using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;
using SeleniumPOM.Utilities;
using System;
using System.Threading;

namespace SeleniumPOM.Tests
{
    [TestFixture]
    internal class TM_Tests : CommonDriver
    {
        [SetUp]
        public void LoginFunction()
        {

            Console.WriteLine("In Login ...... ");
            // Open Chrome Browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [Test]
        public void CreateTM_Test()
        {
            // TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeMaterial(driver);
        }

        [Test]
        public void EditTM_Test()
        {
            // Edit TM
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeMaterialRecord(driver);
        }

        [Test]
        public void DeleteTM_Test()
        {
            // Delete TM
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeMaterialRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            // Close Browser
            driver.Quit();
        }
    }
}