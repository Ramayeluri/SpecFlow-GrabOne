using GrabOneSpecflow.Global;
using GrabOneSpecflow.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace GrabOneSpecflow.Test
      {
           public class Sprint
             {
            [TestFixture]
            [Category("Browse Categories")]

            class GrabOne : Base
            {
                [Test]
                public void RegistrationFunctionality()
                {
                    //Start the reports
                    test = extent.StartTest("Registration functionality");
                    //Create an object for a class Register class
                    Register obj = new Register();
                    //Call the method to check user can register with valid details
                    obj.Navigateregister();
                }
               

                [Test]
                public void SearchServices()
                {
                    //Start the reports
                    test = extent.StartTest("Search Functionality");

                    //Create an object for a  Class to call a method Method
                    HomePage obj1 = new HomePage();
                    //call the method to check user can search the services successfully or not
                    obj1.SearchDentalServices();
                    obj1.ClickSearch();
                }

                [Test]
                public void SubscriptionFunnctionality()
                {
                    //Start the reports
                    test = extent.StartTest("Subscription Functionality");
                    //Create an obj for a class to call a method
                    MySubscription obj = new MySubscription();
                //Call the methods to check User can Subscribe or not
                  obj.TopDeals();
                   obj.ValidateMySub();
                }
            }
        }
    }
