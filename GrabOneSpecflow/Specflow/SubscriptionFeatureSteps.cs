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
    public class SubscriptionFeatureSteps:Base
    {
        [Given(@"I have logged into the application with my credentials")]
        public void GivenIHaveLoggedIntoTheApplicationWithMyCredentials()
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
            
        [When(@"I select Some of the options to subscribe and click on save button")]
        public void WhenISelectSomeOfTheOptionsToSubscribeAndClickOnSaveButton()
        {
           //Create an object for Mysubscription Class to call a method
            MySubscription obj = new MySubscription();
           //Call the method to select Experience, Escape, Bottle and Booknow options to subscribe and click on save button
            obj.TopDeals();
        }

        [Then(@"I should see the message ""(.*)"" on screen")]
        public void ThenIShouldSeeTheMessageOnScreen(string p0)
        {
            //Validate the Subscription functionality
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Subscription Functionality validation");
            //Create an object for MySubscription Class to call a method
            MySubscription obj = new MySubscription();
            //Call the method to check the correct message is displayed or nor
            obj.ValidateMySub();
            Driver.driver.Close();
        }
    }
}
