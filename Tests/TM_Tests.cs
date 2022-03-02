using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;
using System;
using System.Threading;

namespace SeleniumPOM.Tests
{
    internal class TM_Tests
    {   
        static void Main(string[] args)
        {
            // Open Chrome Browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeMaterial(driver);

            // Edit TM
            tMPageObj.EditTimeMaterialRecord(driver);

            // Delete TM
            tMPageObj.DeleteTimeMaterialRecord(driver);

            // Close Browser
            driver.Quit();
        }
    }
}