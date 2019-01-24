using GrabOneSpecflow.Config;
using GrabOneSpecflow.Global;
using GrabOneSpecflow.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace GrabOneSpecflow
{
    [Binding]
    public class SearchDentalServicesSteps : Base
    {
       // private object extent;

        //public string ReportPath { get; private set; }

        [Given(@"User have logged into the GrabOne application")]
        public void GivenUserHaveLoggedIntoTheGrabOneApplication()
        {
            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }
            if (GrabOneResource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User loggedin successfully");
            }
            else
            {
                Register obj = new Register();
                obj.Navigateregister();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User Registered successfully");
            }

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(GrabOneResource.ReportXMLPath);
        }
   
    [When(@"User enter ""(.*)"" keyword on search box and click on search button")]
       
    public void WhenUserEnterKeywordOnSearchBoxAndClickOnSearchButton(string DentalServices)
        {
            //Create an object for HomePage to call a method
            HomePage obj = new HomePage();
            obj.SearchDentalServices();
        }
       

    [Then(@"User Search results for Dental Services should be displayed")]
        public void ThenUserSearchResultsForDentalServicesShouldBeDisplayed()
        {
            // Creates a toggle for the given test, adds all log events under it    
              test = extent.StartTest("Search for Dental Services");
            //Create an objectfor HomePage Class to call a method
            HomePage obj = new HomePage();
            obj.ClickSearch();
            //Close the browser
            Driver.driver.Close();
        }
    }
}
