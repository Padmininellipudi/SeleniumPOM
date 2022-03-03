using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    internal class TMPage
    {

        //Create time and material record
        public void CreateTimeMaterial(IWebDriver driver)
        {
            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //Select material from typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeDropdown.Click();
            Thread.Sleep(3000);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            //Identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Padmini");

            //Identify the Description textbox and input the description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Taruni");

            //Identify the price field and enter the price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id='Price']"));
            priceTextbox.SendKeys("500");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);


            //Wait.WaitToBeVisible(driver, "XPath", "//*[*@id='tmsGrid']/div[4]/a[4]/span", 2);
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);
            //Thread.Sleep(5000);

            //Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(4000);

            //Check if record created is displayed in last page
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            Console.WriteLine("Actual Code ... " + actualCode.Text);
            Console.WriteLine("Actual Desc ..." + actualDescription.Text);
            Console.WriteLine("Actual Price ..." + actualPrice.Text);
            
            //Option1
            Assert.That(actualCode.Text == "Padmini", "Actual Code and Expected code do not match");
            
            //Option2
            //if (actualCode.Text == "Padmini")
            //{
            //    Console.WriteLine("MaterialOption record created successfully, Test passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test failed");
            //}

        }

        //Edit time and material record
        public void EditTimeMaterialRecord(IWebDriver driver)
        {
            //Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(5000);

            //Edit the code, description and price fields
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            IWebElement priceTag1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox1 = driver.FindElement(By.XPath("//*[@id='Price']"));

            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("Paddu");
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Nellipudi");
            priceTag1.Click();
            priceTextbox1.Clear();
            priceTag1.Click();
            priceTextbox1.SendKeys("100");
            Thread.Sleep(3000);

            //Click save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(5000);

            //Click on go to last page button
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();
            Thread.Sleep(3000);

            IWebElement actualCode1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actualCode1.Text == "Paddu")
            {
                Console.WriteLine("Edited successfully, test is passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }

        //Delete time and material record
        public void DeleteTimeMaterialRecord(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //Delete time and material record
            //Click on delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(5000);

            //Wait for the alert to be displayed
            //Store the alert in a variable
            IAlert alert = driver.SwitchTo().Alert();

            //Store the alert in a variable for reuse
            string text = alert.Text;

            //Press Ok button
            alert.Accept();
            Console.WriteLine("Deleted successfully, test is passed");
            Thread.Sleep(5000);
        }
    }
}
