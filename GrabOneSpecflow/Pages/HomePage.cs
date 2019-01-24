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
    class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        #region WebElements Definition
        //Define search bar        
        [FindsBy(How = How.XPath, Using = "//*[@id='search - bar - query']")]
        private IWebElement SearchBar { get; set; }

        //Define search button
        [FindsBy(How = How.XPath, Using = "//*[@id='search - bar']/svg")]
        private IWebElement SearchButton { get; set; }

        #endregion
        public void SearchDentalServices()
        {

            //Enter the "Dental Services" sentence in the search bar
            SearchBar.SendKeys("Dental Services");
            Global.Driver.wait(5);
            //Click on the search button
            SearchButton.Click();

        }
        public void ClickSearch()

        { 
          //Click on the search button
          // SearchButton.Click();
            Driver.wait(5);
            //Thread.Sleep(2000);

            string ExpectedResult = "Dental Services";

            string ActualResult = Global.Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div[1]/a/h3")).Text;
            ////*[@id='mainPage']/div[4]/div[1]/div/div/div[2]/div[2]/div[1]/div[1]/div[1]
            //Check if the property appears  
            Thread.Sleep(2000);
            if (ActualResult == ExpectedResult)
            {
                Thread.Sleep(2000);
                Base.test.Log(LogStatus.Pass, "Test Passed");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "SearchProp");
            }
            else
            {

                Console.WriteLine("Test Failed");
                Base.test.Log(LogStatus.Fail, "Test Failed");
            }
        }
    }
}
