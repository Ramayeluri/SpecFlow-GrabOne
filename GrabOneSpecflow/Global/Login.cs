using GrabOneSpecflow.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using static GrabOneSpecflow.Global.CommonMethods;

namespace GrabOneSpecflow.Global
{
    internal class Login
    {
        //create constructor
        public Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }


        #region  Initialize Web Elements
        //Finding the symbol Login Navigation 
        [FindsBy(How = How.XPath, Using = "//*[@id='banner - account - links']/ul/li[2]/div/button/svg[1]")]
        private IWebElement LoginNavigation { get; set; }

        //Finding the Login from the dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='user - nav - account']/li[7]/a")]
        private IWebElement LoginList { get; set; }


        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//*[@id='login_email']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='login_password']")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@id='login']/fieldset/div[4]/input")]
        private IWebElement LoginButton { get; set; }

        #endregion

        internal void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");

            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));

            //Click on LoginNavigation button
            LoginNavigation.Click();

            //click on Login from the menu list
            LoginList.Click();
            
            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));

            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(2, "Password"));

            // Clicking on the login button
            LoginButton.Click();
        }
    }
}


