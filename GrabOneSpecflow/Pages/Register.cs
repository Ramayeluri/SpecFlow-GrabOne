
using GrabOneSpecflow.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GrabOneSpecflow.Global.CommonMethods;

namespace GrabOneSpecflow.Pages
{

       class Register
        {
            internal Register()
            {
                PageFactory.InitElements(Driver.driver, this);

            }
            //Click on Subscribe Link
            [FindsBy(How = How.XPath, Using = "//*[@id='banner - account - links']/ul/li[3]/a")]
            private IWebElement Subscribe { get; set; }

            //Enter FirstName
            [FindsBy(How = How.XPath, Using = "//*[@id='register_first_name']")]
            private IWebElement FirstName { get; set; }

            //Enter LastName
            [FindsBy(How = How.XPath, Using = "//*[@id='register_last_name']")]
            private IWebElement LastName { get; set; }

            //click on Email
            [FindsBy(How = How.XPath, Using = "//*[@id='register_email']")]
            private IWebElement Email { get; set; }

            //Click on Password
            [FindsBy(How = How.XPath, Using = "//*[@id='register_raw_password']")]
            private IWebElement Password { get; set; }

             //Click on Re-enter Password
             [FindsBy(How = How.XPath, Using = "//*[@id='register_reenter_password']")]
             private IWebElement RePassword { get; set; }

            //Select Region from dropdown 
            [FindsBy(How = How.XPath, Using = "//*[@id='register_default_area_id']")]
            private IWebElement RegDropdown { get; set; }

            //Accept terms and conditions
            [FindsBy(How = How.XPath, Using = "//*[@id='register_terms_and_conditions']")]
            private IWebElement Terms { get; set; }

            //Click on Register Button
            [FindsBy(How = How.XPath, Using = "//*[@id='register']/fieldset/div[8]/input")]
            private IWebElement RegisterButton { get; set; }

            internal void Navigateregister()
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Register");

                // Navigating to Login page using value from Excel
                Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));

                //Click on the Subscribe button
                Subscribe.Click();

                Driver.wait(2);
                //Read FirstName
                FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));

                //Read LastName
                LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));

                //Read Email
                Email.SendKeys(ExcelLib.ReadData(2, "Email"));

                Driver.wait(2);
                //Read Password
                Password.SendKeys(ExcelLib.ReadData(2, "Password"));

                //Read the password and again enter the password
                RePassword.SendKeys(ExcelLib.ReadData(2, "Password"));

            //SelectAuckland  Region from the dropdown list
            RegDropdown.Click();
            IWebElement Reg = Driver.driver.FindElement(By.XPath("//*[@id='register_default_area_id']"));
            Thread.Sleep(4000);
            IList<IWebElement> RegList = Reg.FindElements(By.TagName("div"));
            for (int i = 0; i < RegList.Count; i++)
            {
                if (RegList[i].Text == ExcelLib.ReadData(7, "InputValue").Trim())
                {
                    Thread.Sleep(3000);
                    RegList[i].Click();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Region Auckland Selected");
                }
            }
            Thread.Sleep(3000);

            //Click on Terms and Conditions
            Terms.Click();

            //Click on Register button
             RegisterButton.Click();

            }
        }
    }

