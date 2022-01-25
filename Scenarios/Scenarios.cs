using AventStack.ExtentReports;
using MoneyCorp.Base;
using MoneyCorp.Extensions;
using MoneyCorp.Pages;
using MoneyCorp.TestData;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Threading;

namespace MoneyCorp.Scenarios
{
   /// <summary>
    /// Summary description for MoneyCorp validation Scenarios
    /// </summary>
   
    [TestFixture] //Marks a class that contains tests.

    class Scenarios : BaseClass
    {
        MoneyCorpTestData obj1 = new MoneyCorpTestData();
        MoneyCorpHomePage obj2 = new MoneyCorpHomePage();
        MoneyCorpDetailPage obj3 = new MoneyCorpDetailPage();
        MoneyCorpInternationalPaymentPage obj4 = new MoneyCorpInternationalPaymentPage();

        #region Member Functions        
        [Test,Category("Regression Cycle")] //including the test category along the test attribute, to include in test context below
         
        public void ValidateMoneyCorpSite()
        {
            //Method Calling from different page classes.
                Thread.Sleep(5000); //this way we can include sleep waits but they are not recommended
                obj2.AcceptCookies();   //accept_cookies:to accept the cookies modal dialog
                obj2.Click(obj2.languageIconElement, "language icon clicked");  //calling element within generic method
                obj2.ScrollToUSAEnglishOptionAndClick(obj2.countryUSAOptionElement);
                obj2.ScrollTofindOutMoreButtonAndClick(obj2.findOutMoreButtonElement);
                Assert.IsTrue(obj3.CheckPageURL(obj1.foreignExchangeSolutionPageURL), "User has arrived on Foreign exchange solutions Page"); //Assertions added
                obj3.Click(obj3.searchIconElement, "click search icon");
                obj3.EnterText(obj3.searchTextFieldElement, obj1.searchText, extentReportsHelper, "Search Text Field"); //calling the element extension methods
                obj3.ClickEnter(obj3.searchTextFieldElement);
                Assert.IsTrue(obj4.CheckPageURL(obj1.internationapPaymentsPageURL), "User has arrived on International Payment Page"); //Assertions added
                Assert.IsTrue(obj4.ValidateLinks(), "User has validated the links");
        }


        
        [TearDown] //There should be at least one method per test class. Marks a method that should be called after each test method.

        public void Results() //this method is to capture the context details like MethodName,ClassName,Pass/Fail status of the Test Method, Stack Trace for Failed method
        {
            string methodName = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Name of the method - " + methodName);

            string className = TestContext.CurrentContext.Test.ClassName;
            Console.WriteLine("Name of the classname - " + className);

            string statusName = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            Console.WriteLine("Name of the status - " + statusName);

            string stackName = TestContext.CurrentContext.Result.StackTrace;
            Console.WriteLine("Stackrace - " + stackName);

            string categoryName = TestContext.CurrentContext.Test.Properties.Get("Category").ToString(); // If the category name is given in the test
            Console.WriteLine("Category name - " + categoryName);

            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extentReportsHelper.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        extentReportsHelper.AddTestFailureScreenshot(driver.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        extentReportsHelper.SetTestStatusSkipped();
                        break;
                    default:
                        extentReportsHelper.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        #endregion
    }
}

