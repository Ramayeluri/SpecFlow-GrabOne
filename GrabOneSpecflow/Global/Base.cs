
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using GrabOneSpecflow.Global;
using static GrabOneSpecflow.Global.CommonMethods;
using GrabOneSpecflow.Config;

namespace GrabOneSpecflow.Global
{
  
       //[TextFixture]
        public class Base
        {
            #region To access Path from resource file

            public static int Browser = Int32.Parse(GrabOneResource.Browser);
            public static String ExcelPath = GrabOneResource.ExcelPath;
            public static string ScreenshotPath = GrabOneResource.ScreenShotPath;
            public static string ReportPath = GrabOneResource.ReportPath;
            //#endregion

            #region reports
            public static ExtentTest test;
            public static ExtentReports extent;
            #endregion

            #region setup and tear down
            [SetUp]
            public void Inititalize()
            {

                // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
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
                }
               // else
               // {
                 //   Register obj = new Register();
                 //   obj.Navigateregister();
               // }
                extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
                extent.LoadConfig(GrabOneResource.ReportXMLPath);
            }


            [TearDown]
            public void TearDown()
            {
                // Screenshot
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                Console.WriteLine();
                Console.WriteLine(img);
                //  test.Log(LogStatus.Info, "Image example: " + img);
                // end test. (Reports)
                extent.EndTest(test);
                // calling Flush writes everything to the log file (Reports)
                extent.Flush();
                // Close the driver :)            
                //Driver.driver.Close();
            }
            #endregion

        }
    }
#endregion
